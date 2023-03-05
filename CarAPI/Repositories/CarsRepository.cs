using CarLib;

namespace CarAPI.Repositories
{
    public class CarsRepository
    {
        private int _nextID;
        public List<Car> cars;

        public CarsRepository()
        {
            _nextID = 1;
            cars = new List<Car>()
            {
                new Car() {Id = _nextID++, Model = "abcde", Price = 100, LicensePlate = "abcde"},
                new Car() {Id = _nextID++, Model = "fghij", Price = 100, LicensePlate = "fghij"},
                new Car() {Id = _nextID++, Model = "klmno", Price = 100, LicensePlate = "klmno"}
            };
        }

        public List<Car> GetAll()
        {
            return new List<Car>(cars);
        }
        public Car Add(Car newCar)
        {
            newCar.ValidateCar();
            newCar.Id = _nextID++;
            cars.Add(newCar);
            return newCar;
        }
        public Car Delete(int Id)
        {
            Car deleteCar = GetById(Id);
            cars.Remove(deleteCar);
            return deleteCar;
        }
        public Car GetById(int Id)
        {
            if (!cars.Exists(c => c.Id == Id))
            {
                throw new KeyNotFoundException($"No Car with the ID: {nameof(Id)}");
            }
            return cars.Find(c => c.Id == Id);
        }
        public Car? Update(int Id, Car car)
        {
            car.ValidateCar();
            Car updatedCar = GetById(Id);
            if (updatedCar is not null)
            {
                updatedCar.Model = car.Model;
                updatedCar.Price = car.Price;
                updatedCar.LicensePlate = car.LicensePlate;
            }
            return updatedCar;
        }

    }
}
