using MelonStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MelonStore.Data.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Count).HasColumnName("Count");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.BasePrice).HasColumnName("BasePrice");
            this.Property(t => t.Image_Id).HasColumnName("Image_Id");

            // Relationships
            this.HasOptional(t => t.Image)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.Image_Id);

        }
    }
}
