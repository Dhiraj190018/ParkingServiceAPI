# ParkingServiceAPI

## Synopsis

Restful WCF service to get Parking Lot information like **availability**, **total space** etc. and Vehicle information like **outstanding fees at checkout or anytime**


## API Reference call examples

**get lot information format=xml**

http://localhost:61609/ParkingService.svc/lot/2 

OR

http://localhost:61609/ParkingService.svc/lot/2?format=xml

**get lot information format=json**

http://localhost:61609/ParkingService.svc/lot/2 

OR

http://localhost:61609/ParkingService.svc/lot/2?format=json

**get vehicle information format=xml**

http://localhost:61609/ParkingService.svc/vehicle/2

OR

http://localhost:61609/ParkingService.svc/vehicle/2?format=xml 

**get vehicle information format=json**

http://localhost:61609/ParkingService.svc/vehicle/2?format=json 

## Code Reference

Uses Autofac for Dependency Injection
Uses Global.asax - Application_Start event to initialize single instances and register dependencies in DI tree

## Unit Tests (Use Moq for mocking and data set up): 

https://github.com/Dhiraj190018/ParkingServiceAPI/blob/master/ParkingServiceAPI/Test/ParkingServiceAPI.ImplementationTests/ParkingFeesCalculatorTests.cs
https://github.com/Dhiraj190018/ParkingServiceAPI/blob/master/ParkingServiceAPI/Test/ParkingServiceAPI.ImplementationTests/ParkingServiceImplementationTests.cs
