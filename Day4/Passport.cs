namespace Day4
{
    public class Passport
    {
        public int? birthYear;
        public int? issueYear;
        public int? expirationYear;
        public string height;
        public string hairColor;
        public string eyeColor;
        public string passportId;
        public int? countryId;

        public bool IsValid()
        {
            if (birthYear.HasValue && issueYear.HasValue && expirationYear.HasValue
                && !string.IsNullOrEmpty(height) && !string.IsNullOrEmpty(hairColor) && !string.IsNullOrEmpty(eyeColor)
                && !string.IsNullOrEmpty(passportId) && countryId.HasValue) return true;
            else if (birthYear.HasValue && issueYear.HasValue && expirationYear.HasValue
                && !string.IsNullOrEmpty(height) && !string.IsNullOrEmpty(hairColor) && !string.IsNullOrEmpty(eyeColor)
                && !string.IsNullOrEmpty(passportId)) return true;
            else 
                return false;

        }

    }
}