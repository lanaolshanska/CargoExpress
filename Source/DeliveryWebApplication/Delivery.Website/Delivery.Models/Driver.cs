using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delivery.Models
{
    public class Driver
    {
        public int Id { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contain only letters")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contain only letters")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthday Date")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Phone")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "CellPhone must contain only numbers")]
        public string CellPhone { get; set; }

        public string Address { get; set; }

        [Display(Name = "Driver since")]
        [Range(1900, 2019, ErrorMessage = "Year must be in range between 1900 and 2019")]
        public int? StartedDrivingYear { get; set; }

        [Display(Name = "Total trips")]
        public int TripsTotal { get; set; }

        [Display(Name = "Has criminal record")]
        public bool HasCriminalRecord { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "int")]
        public DriverStatus? Status { get; set; }
    }
}