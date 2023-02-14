using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLib.Tests
{
    [TestClass()]
    public class CarTests
    {
        private Car car = new() { Id = 1, Model = "test", Price = 1, LicensePlate = "AB"};
        private Car car2 = new() { Id = 1, Model = "test", Price = 1, LicensePlate = "ABC1234" };
        private Car carModelNull = new() { Id = 2, Model = null, Price = 50000};
        private Car carModelLessThanFour = new() { Id = 3, Model = "hej", Price = 50000, LicensePlate = "ABC123" };
        private Car carPriceLessThanOne = new() { Id = 4, Model = "test", Price = 0, LicensePlate = "ABC123" };
        private Car carLicensePlateNull = new() { Id = 5, Model = "test", Price = 50000, LicensePlate = null };
        private Car carLicensePlateLessThanTwo = new() { Id = 6, Model = "test", Price = 50000, LicensePlate = "A" };
       
        [TestMethod()]
        public void ValidateModelExceptionTest()
        {
            car.ValidateModel();
            Assert.ThrowsException<ArgumentNullException>(() => carModelNull.ValidateModel());
            Assert.ThrowsException<ArgumentException>(() => carModelLessThanFour.ValidateModel());
        }
       
        [TestMethod()]
        public void ValidateModelPassingTest()
        {
            car.ValidateModel();
            Assert.AreEqual("test", car.Model);
        }
        
        [TestMethod()]
        public void ValidatePriceExceptionTest()
        {
            car.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => carPriceLessThanOne.ValidatePrice());
        }
        
        [TestMethod()]
        public void ValidatePricePassingTest()
        {
            car.ValidatePrice();
            Assert.AreEqual(1, car.Price);
        }

        [TestMethod()]
        public void ValidateLicensePlateExceptionTest()
        {
            car.ValidateLicensePlate();
            Assert.ThrowsException<ArgumentNullException>(() => carLicensePlateNull.ValidateLicensePlate());
            Assert.ThrowsException<ArgumentException>(() => carLicensePlateLessThanTwo.ValidateLicensePlate());
        }

        [TestMethod()]
        public void ValidateLicensePlatePassingTest()
        {
            car.ValidateLicensePlate();

            Assert.AreEqual("AB", car.LicensePlate);
            Assert.AreEqual("ABC1234", car2.LicensePlate);
        }

        [TestMethod()]
        public void ValidateCarTest()
        {
            car.ValidateCar();
            Assert.ThrowsException<ArgumentException>(() => carModelLessThanFour.ValidateModel());
        }
    }
}