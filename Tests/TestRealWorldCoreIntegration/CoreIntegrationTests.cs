using Fonlow.RealWorldService.ClientData;
using Fonlow.RealWorldService.Clients;
using System.ServiceModel;

namespace TestRealWorldCoreIntegration
{
	public class CoreIntegrationTests
	{
		const string realWorldEndpoint = "DefaultBinding_RealWorld";
		readonly BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
		readonly EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8998/RealWorldServices/RealWorld.svc");

		[Fact]
		public void TestGetData()
		{
			using (Service1Client client = new Service1Client(binding, endpointAddress))
			{
				Assert.Contains("1234", client.GetData(1234));
			}

			using (Service1Client client = new Service1Client(binding, endpointAddress))
			{
				try
				{
					Assert.Contains("1234", client.GetData(666));
					Assert.Fail("Expect fault");
				}
				catch (FaultException<Evil666Error> e)
				{
					Assert.Contains("666", e.Detail.Message);
				}
			}

		}

		[Fact]
		public void TestGetDataUsingDataContract()
		{
			
			using (Service1Client client = new Service1Client(binding, endpointAddress))
			{
				CompositeType data = new CompositeType()
				{
					BoolValue = true,
					StringValue = "Good",
				};

				CompositeType result = client.GetDataUsingDataContract(data);
				Assert.Equal("GoodSuffix", result.StringValue);
			}

			using (Service1Client client = new Service1Client(binding, endpointAddress))
			{
				CompositeType data = new CompositeType()
				{
					BoolValue = false,
					StringValue = "Good",
				};
				CompositeType result = client.GetDataUsingDataContract(data);
				Assert.Equal("Good", result.StringValue);
			}

			using (Service1Client client = new Service1Client(binding, endpointAddress))
			{
				try
				{
					CompositeType result = client.GetDataUsingDataContract(null);
					Assert.Fail("Hey, I expect FaultException.");
				}
				catch (System.ServiceModel.FaultException)
				{
					Assert.True(true, "Very good, excepted.");
				}
			}

		}

	}
}