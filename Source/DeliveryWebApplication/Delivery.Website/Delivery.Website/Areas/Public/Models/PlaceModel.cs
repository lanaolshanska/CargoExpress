namespace Delivery.Website.Areas.Public.Models
{
    public abstract class PlaceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class StateModel:PlaceModel
    {
    }

    public class CityModel : PlaceModel
    {
    }
}
