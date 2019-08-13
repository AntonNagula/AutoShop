using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using магазин_авто.Models;
namespace магазин_авто.Configurations
{
    public class ConfigBuyer : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {

            builder.HasKey(t => t.Id);
            
        }
    }
}