using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingServiceAPI.Common;
using ParkingServiceAPI.DataAccess;
using ParkingServiceAPI.DataContract;
using ParkingServiceAPI.FaultContract.DataContract;
using ParkingServiceAPI.FaultContract.FaultContract;

namespace ParkingServiceAPI.ImplementationTests
{
    [TestClass()]
    public class ParkingServiceImplementationTests
    {
        private Mock<IParkingServiceUtilities> _mockParkingServiceUtilities;
        private Mock<IParkingServiceDatabaseAccess> _mockParkingServiceDatabaseAccess;
        private Mock<IParkingFeesCalculator> _mockParkingFeesCalculator;

        private IParkingServiceImplementation _instance;


        public ParkingServiceImplementationTests()
        {
            TestInitialize();
        }

        private void TestInitialize()
        {
            _mockParkingServiceUtilities = new Mock<IParkingServiceUtilities>();
            _mockParkingServiceDatabaseAccess = new Mock<IParkingServiceDatabaseAccess>();
            _mockParkingFeesCalculator = new Mock<IParkingFeesCalculator>();
            
        }

        [TestMethod()]
        public void GetVehicleInformationTest()
        {
            _mockParkingServiceDatabaseAccess.Setup(x => x.GetVehicleInfoFromDb("2"))
                .Returns(() => new VehicleInformation() {VehicleId = "2", VehicleName = "Tesla", OutstandingAmount = 100});
            _mockParkingFeesCalculator.Setup(x => x.CalculateFees(It.IsAny<double>())).Returns(100);
        _instance = new ParkingServiceImplementation(_mockParkingServiceUtilities.Object, _mockParkingFeesCalculator.Object, _mockParkingServiceDatabaseAccess.Object);

            var vehicle = _instance.GetVehicleInformation("2");

            Assert.AreEqual(vehicle.VehicleId, "2");
            Assert.AreEqual(vehicle.OutstandingAmount, 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(FaultException<ServiceFault>))]
        public void GetVehicleInformationTest_NullVehicleInformation()
        {
            _mockParkingServiceDatabaseAccess.Setup(x => x.GetVehicleInfoFromDb("2"))
                .Returns(() => null);
            _mockParkingFeesCalculator.Setup(x => x.CalculateFees(It.IsAny<double>())).Returns(100);
            _instance = new ParkingServiceImplementation(_mockParkingServiceUtilities.Object, _mockParkingFeesCalculator.Object, _mockParkingServiceDatabaseAccess.Object);

            var vehicle = _instance.GetVehicleInformation("2");
        }

        [TestMethod()]
        public void GetLotAvailabilityTest()
        {
            _mockParkingServiceDatabaseAccess.Setup(x => x.GetLotInfoFromDb("2"))
                .Returns(() => new LotInformation() { LotId = "2", LotName = "Beaverton", CurrentAvailability = "100" });
            _mockParkingFeesCalculator.Setup(x => x.CalculateFees(It.IsAny<double>())).Returns(100);
            _instance = new ParkingServiceImplementation(_mockParkingServiceUtilities.Object, _mockParkingFeesCalculator.Object, _mockParkingServiceDatabaseAccess.Object);

            var lot = _instance.GetLotAvailability("2");

            Assert.AreEqual(lot.LotId, "2");
            Assert.AreEqual(lot.CurrentAvailability, "100");
        }
    }
}