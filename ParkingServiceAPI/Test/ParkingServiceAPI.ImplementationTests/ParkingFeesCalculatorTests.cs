using Castle.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingServiceAPI.Common;
using ParkingServiceAPI.DataContract;

namespace ParkingServiceAPI.ImplementationTests
{
    [TestClass()]
    public class ParkingFeesCalculatorTests
    {
        private Mock<IConfigurationRepository> _mockConfigurationRepository;
        private IParkingFeesCalculator _instance;


        public ParkingFeesCalculatorTests()
        {
            TestInitialize();
        }

        private void TestInitialize()
        {
            _mockConfigurationRepository = new Mock<IConfigurationRepository>();
        }

        [TestMethod()]
        public void ParkingFeesCalculatorTestHours_2()
        {
            _mockConfigurationRepository.Setup(x => x.Get("PerDayCharges")).Returns("15");
            _mockConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns("((0-2:5))((2-10:10))((10-24:15))");
            _instance = new ParkingFeesCalculator(_mockConfigurationRepository.Object);

            var fees = _instance.CalculateFees(2);

            Assert.AreEqual(5,fees);
        }

        [TestMethod()]
        public void ParkingFeesCalculatorTestHours_2Dot5()
        {
            _mockConfigurationRepository.Setup(x => x.Get("PerDayCharges")).Returns("15");
            _mockConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns("((0-2:5))((2-10:10))((10-24:15))");
            _instance = new ParkingFeesCalculator(_mockConfigurationRepository.Object);
            var fees = _instance.CalculateFees(2.5);
            Assert.AreEqual(10, fees);
        }

        [TestMethod()]
        public void ParkingFeesCalculatorTestHours_6()
        {
            _mockConfigurationRepository.Setup(x => x.Get("PerDayCharges")).Returns("15");
            _mockConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns("((0-2:5))((2-10:10))((10-24:15))");
            _instance = new ParkingFeesCalculator(_mockConfigurationRepository.Object);

            var fees = _instance.CalculateFees(6);
            Assert.AreEqual(10, fees);
        }

        [TestMethod()]
        public void ParkingFeesCalculatorTestHours_26()
        {
            _mockConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns("((0-2:5))((2-10:10))((10-24:15))");
            _mockConfigurationRepository.Setup(x => x.Get("PerDayCharges")).Returns("15");
            _instance = new ParkingFeesCalculator(_mockConfigurationRepository.Object);

            var fees = _instance.CalculateFees(26);
            Assert.AreEqual(20, fees);
        }
        
    }
}