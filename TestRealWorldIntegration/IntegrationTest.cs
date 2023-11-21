using Fonlow.RealWorldService.ClientData;
using Fonlow.RealWorldService.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace TestRealWorldIntegration
{
	/// <summary>
	/// Summary description for Integration
	/// </summary>
	[TestClass]
	public class IntegrationTest
	{
		public IntegrationTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		const string realWorldEndpoint = "DefaultBinding_RealWorld";

		[TestMethod]
		public void TestGetData()
		{
			using (Service1Client client = new Service1Client(realWorldEndpoint))
			{
				Assert.IsTrue(client.GetData(1234).Contains("1234"));
			}

			using (Service1Client client = new Service1Client(realWorldEndpoint))
			{
				try
				{
					Assert.IsTrue(client.GetData(666).Contains("1234"));
					Assert.Fail("Expect fault");
				}
				catch (FaultException<Evil666Error> e)
				{
					Assert.IsTrue(e.Detail.Message.Contains("666"));
				}
			}

		}

		[TestMethod]
		public void TestGetDataUsingDataContract()
		{
			using (Service1Client client = new Service1Client(realWorldEndpoint))
			{
				CompositeType data = new CompositeType()
				{
					BoolValue = true,
					StringValue = "Good",
				};

				CompositeType result = client.GetDataUsingDataContract(data);
				Assert.AreEqual("GoodSuffix", result.StringValue);
			}

			using (Service1Client client = new Service1Client(realWorldEndpoint))
			{
				CompositeType data = new CompositeType()
				{
					BoolValue = false,
					StringValue = "Good",
				};
				CompositeType result = client.GetDataUsingDataContract(data);
				Assert.AreEqual("Good", result.StringValue);
			}

			using (Service1Client client = new Service1Client(realWorldEndpoint))
			{
				try
				{
					CompositeType result = client.GetDataUsingDataContract(null);
					Assert.Fail("Hey, I expect FaultException.");
				}
				catch (System.ServiceModel.FaultException)
				{
					Assert.IsTrue(true, "Very good, excepted.");
				}
			}

		}
	}
}
