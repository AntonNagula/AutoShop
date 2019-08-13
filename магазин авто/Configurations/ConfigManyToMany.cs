using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using магазин_авто.Models;

namespace магазин_авто.Configurations
{
    public class ConfigManyToMany : IEntityTypeConfiguration<BuyCar>
    {
        public void Configure(EntityTypeBuilder<BuyCar> builder)
        {

            builder.HasKey(t => new { t.BuyerId, t.CarId });

            builder
                .HasOne(sc => sc.Buyer)
                .WithMany(s => s.BuyCars)
                .HasForeignKey(sc => sc.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(sc => sc.Car)
                .WithMany(s => s.BuyCars)
                .HasForeignKey(sc => sc.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}