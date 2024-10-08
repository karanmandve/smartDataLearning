using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService, IDisposable
    {

        public Guid ServiceInstanceId { get; }

        private List<string> _cities;
        public CitiesService()
        {
            ServiceInstanceId = Guid.NewGuid();

            _cities = new List<string>()
            {
                "London",
                "Paris",
                "New York",
                "Tokyo",
                "Rome"
            };


            // OPEN THE DB CONNECTION

        }


        public List<string> GetCities()
        {
            return _cities;

        }

        public void Dispose()
        {
            // CLOSE THE DB CONNECTION
        }
    }
}
