using System.IO;

namespace Delivery.Website.Areas.Admin.Contracts
{
    public interface IFileGenerator
    {
        StringWriter GenerateDriverReport();
        StringWriter GenerateShipmentReport();
    }
}
