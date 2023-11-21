cd %~dp0
:: generate wsdl. Run this when there's a breaking change in the interface. You still need to be careful about interface versioning.
"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\svcutil.exe" bin\Debug\Fonlow.RealWorldService.dll /directory:..\deployment