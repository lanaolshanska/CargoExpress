using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Delivery.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "First name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Firstname must contain only letters")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contain only letters")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "CellPhone must contain only numbers")]
        public string CellPhone { get; set; }

        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public int? UserId { get; set; }

        [JsonIgnore]
        public virtual List<Cargo> CargosSent { get; set; }
        [JsonIgnore]
        public virtual List<Cargo> CargosReceived { get; set; }
    }
}
