using System.Collections.Generic;

namespace Delivery.Website.Areas.Admin.Models
{
    public class NavigationModel
    {
        public string Title { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public List<NavigationModel> Submenu { get; set; }
        public object RouteParameters { get; set; }
    }
}