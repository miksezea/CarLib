namespace CarLib
{
    /// <summary>
    /// Klassen Car
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Id nummer til bilobjekt
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Modeltype til bilobjekt
        /// </summary>
        public string? Model { get; set; }

        /// <summary>
        /// Pris til bilobjekt
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Nummerplade til bilobjekt
        /// </summary>
        public string? LicensePlate { get; set; }

        /// <summary>
        /// Validering af Model property
        /// </summary>
        /// <exception cref="ArgumentNullException">Hvis Model value er null</exception>
        /// <exception cref="ArgumentException">Hvis Model value er mindre end 4 tegn</exception>
        public void ValidateModel()
        {
            if (Model == null)
                throw new ArgumentNullException("Model name can't be null");
            if (Model.Length < 4)
                throw new ArgumentException($"Model name can't be shorter than 4 letters. You typed: {nameof(Model)}");
        }

        /// <summary>
        /// Validering af Price property
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Hvis Price er mindre end 1</exception>
        public void ValidatePrice()
        {
            if (Price <= 0)
                throw new ArgumentOutOfRangeException("Price cannot be 0 or less");
        }

        /// <summary>
        /// Validering af LicensePlate property
        /// </summary>
        /// <exception cref="ArgumentNullException">Hvis LicensePlate value er null</exception>
        /// <exception cref="ArgumentException">Hvis LicensePlate value ikke er mellem 2 og 7 tegn</exception>
        public void ValidateLicensePlate()
        {
            if (LicensePlate == null)
                throw new ArgumentNullException("Licenseplate can't be null");
            if (LicensePlate.Length < 2 || 7 < LicensePlate.Length)
                throw new ArgumentException($"License should be between 2 and 7 characters. You typed: {nameof(LicensePlate)}");
        }

        /// <summary>
        /// Alle valideringsmetoder samlet
        /// </summary>
        public void ValidateCar()
        {
            ValidateModel();
            ValidatePrice();
            ValidateLicensePlate();
        }
    }
}