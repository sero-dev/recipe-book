using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class WeeklyMenuItemConfiguration : IEntityTypeConfiguration<WeeklyMenuItem>
    {
        public void Configure(EntityTypeBuilder<WeeklyMenuItem> builder)
        {
            builder.ToTable("WeeklyMenu");

            builder.HasOne(b => b.LunchRecipe)
                .WithMany();

            builder.HasOne(b => b.DinnerRecipe)
                .WithMany();
        }
    }
}
