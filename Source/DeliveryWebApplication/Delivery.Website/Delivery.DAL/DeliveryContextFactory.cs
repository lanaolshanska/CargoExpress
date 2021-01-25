using Microsoft.EntityFrameworkCore;

namespace Delivery.DAL
{
    public class DeliveryContextFactory
    {
        private readonly string url;

        public DeliveryContextFactory(string url)
        {
            this.url = url;
        }

        public DeliveryContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DeliveryContext>()
                .UseLazyLoadingProxies(true)
                .UseSqlServer(url);
            return new DeliveryContext(optionsBuilder.Options);
        }
    }
}
