using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAPI.Repositories;
using CarLib;

namespace CarTest.CarAPI
{
    [TestClass()]
    public class CarTests
    {
        private CarsRepository repository;

        [TestInitialize]
        public void BeforeEachTest()
        {
            repository = new CarsRepository();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var actual = repository.GetAll();

            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(typeof(List<Car>), actual.GetType());
        }


        [TestMethod()]
        public void AddTest()
        {
            Car testCar = new() { Model = "test", Price = 100, LicensePlate = "test" };
            repository.Add(testCar);
            var actual = repository.GetById(testCar.Id);

            Assert.AreEqual(4, actual.Id);
            Assert.AreEqual(100, actual.Price);
            Assert.AreEqual(typeof(Car), actual.GetType());
        }
    }
}
