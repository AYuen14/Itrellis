Special Instructions: <br />

Domain: Car Dealership <br />
Interface: WEB UI (SPA) <br />

Current libaries: <br />
Dapper <br />
Autofac <br />
NUnit <br />
MOQ <br />
FluentAssertions <br />

Deploying the App: <br />

Steps  <br />
1.Please clone code from https://github.com/AYuen14/Itrellis/tree/master/CarDealership <br />
2.Do a nuget restore. <br />
3.Build the solution through visual studio 2015+ <br />
4.Set up IIS <br />
	a. Open IIS and create a new website <br />
	b. SiteName: local.CarDealership.com <br />
		Physical Path: Point to CarDealership folder from the cloned repository <br />
		HostName:local.CarDealership.com <br />
		Note: Ip address and port can be set to default. <br />
	c.Go To application pools <br />
		a.Right click on the new application that was created through IIS <br />
		b. Click on Advance Settings <br />
		c. Set .NET framework to 4.0 and Enable 32 bit applications = true <br />
5.Create an Entry in host file <br />
	a. 127.0.0.1 local.CarDealership.com <br />
	b.Save as admin <br />
6.Navigate to local.CarDealership.com <br />