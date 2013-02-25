using FileHelpers;

namespace CaryCrimes.Models
{
    [DelimitedRecord(",")]
    [IgnoreEmptyLines]
    public class CrimeDetail
    {
        public string IncidentDate;
        public string Street;
        public string Category;
        public string Lat;
        public string Lon;
    }
}