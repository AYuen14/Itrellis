Special Instructions:

Domain: Car Dealership
Interface: WEB UI (SPA)

Current libaries:
Dapper
Autofac
NUnit
MOQ
FluentAssertions

Deploying the App:

Steps 
1.Please clone code from https://github.com/AYuen14/Itrellis/tree/master/CarDealership
2.Do a nuget restore.
3.Build the solution through visual studio 2015+
4.Set up IIS
	a. Open IIS and create a new website
	b. SiteName: local.CarDealership.com
		Physical Path: Point to CarDealership folder from the cloned repository
		HostName:local.CarDealership.com
		Note: Ip address and port can be set to default.
	c.Go To application pools
		a.Right click on the new application that was created through IIS
		b. Click on Advance Settings
		c. Set .NET framework to 4.0 and Enable 32 bit applications = true
5.Create an Entry in host file
	a. 127.0.0.1 local.CarDealership.com
	b.Save as admin
6.Navigate to local.CarDealership.com