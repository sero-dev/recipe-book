using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence.Configurations
{
    public class WeeklyMenuItemConfiguration : IEntityTypeConfiguration<WeeklyMenuItem>
    {
        public void Configure(EntityTypeBuilder<WeeklyMenuItem> builder)
        {
            builder.ToTable("WeeklyMenu");

            builder.Property(b => b.Day)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasOne(b => b.LunchRecipe)
                .WithMany();

            builder.HasOne(b => b.DinnerRecipe)
                .WithMany();
        }
    }
}
