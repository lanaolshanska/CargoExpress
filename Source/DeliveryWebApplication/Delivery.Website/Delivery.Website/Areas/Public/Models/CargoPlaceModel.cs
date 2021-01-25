using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Delivery.Website.Areas.Public.Models
{
    public class CargoPlaceModel
    {
        [Required(ErrorMessage = "Select state")]
        [Display(Name = "State")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Select city")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public IEnumerable<StateModel> States { get; set; }
        public IEnumerable<CityModel> Cities { get; set; }

        public CargoPlaceModel()
        {
            States = Enumerable.Empty<StateModel>();
            Cities = Enumerable.Empty<CityModel>();
        }
    }
}