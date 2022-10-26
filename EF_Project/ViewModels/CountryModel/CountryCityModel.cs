using EF_Project.ViewModels.CityModel;

namespace EF_Project.ViewModels.CountryModel
{
    public class CountryCityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityResponseModel> Cities { get; set; }
    }
}
