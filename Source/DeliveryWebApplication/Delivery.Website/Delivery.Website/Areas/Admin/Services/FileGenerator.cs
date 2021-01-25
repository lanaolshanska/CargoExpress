using Delivery.BL.Contracts;
using Delivery.Website.Areas.Admin.Contracts;
using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Delivery.Website.Areas.Admin.Services
{
    public class FileGenerator : IFileGenerator
    {
        private readonly IDriverService _driverService;

        public FileGenerator(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public StringWriter GenerateDriverReport()
        {
            var data = _driverService.GetTop5().ToList();

            var grid = new GridView
            {
                DataSource = data
            };
            grid.DataBind();

            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            return sw;
        }

        public StringWriter GenerateShipmentReport()
        {
            throw new NotImplementedException();
        }
    }
}