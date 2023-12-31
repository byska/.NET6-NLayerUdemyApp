﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Product { Id = 1, Name = "Kalem 1", CategoryId = 1, Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product { Id = 1, Name = "Kalem 2", CategoryId = 1, Price = 200, Stock = 30, CreatedDate = DateTime.Now },
                new Product { Id = 1, Name = "Kalem 3", CategoryId = 1, Price = 600, Stock = 60, CreatedDate = DateTime.Now },
                new Product { Id = 1, Name = "Kalem 3", CategoryId = 1, Price = 600, Stock = 60, CreatedDate = DateTime.Now },

                new Product { Id = 1, Name = "Kitap 1", CategoryId = 2, Price = 600, Stock = 60, CreatedDate = DateTime.Now },
                new Product { Id = 1, Name = "Kitap 2", CategoryId = 2, Price = 6600, Stock = 320, CreatedDate = DateTime.Now }

                );
        }
    }
}
