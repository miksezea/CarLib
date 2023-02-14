namespace CarLib
{
    public class Car
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Price { get; set; }
        public string? LicensePlate { get; set; }
        public void ValidateModel()
        {
            if (Model == null)
                throw new ArgumentNullException("Model name can't be null");
            if (Model.Length < 4)
                throw new ArgumentException($"Model name can't be shorter than 4 letters. You typed: {nameof(Model)}");
        }
        public void ValidatePrice()
        {
            if (Price <= 0)
                throw new ArgumentOutOfRangeException("Price cannot be 0 or less");
        }
        public void ValidateLicensePlate()
        {
            if (LicensePlate == null)
                throw new ArgumentNullException("Licenseplate can't be null");
            if (LicensePlate.Length < 2 || 7 < LicensePlate.Length)
                throw new ArgumentException($"License should be between 2 and 7 characters. You typed: {nameof(LicensePlate)}");
        }
        public void ValidateCar()
        {
            ValidateModel();
            ValidatePrice();
            ValidateLicensePlate();
        }
    }
}