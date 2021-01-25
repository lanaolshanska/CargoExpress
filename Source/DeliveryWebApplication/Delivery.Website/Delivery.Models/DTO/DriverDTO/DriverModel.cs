namespace Delivery.Models.DTO
{
    public class DriverModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public int? StartedDrivingYear { get; set; }
        public bool HasCriminalRecord { get; set; }
    }
}