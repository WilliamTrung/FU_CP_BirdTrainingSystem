using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Context
{
    public static class AddEntities
    {
        public static void AddEntityType(this ModelBuilder builder)
        {
            builder.Entity<EntityType>().HasData(
                new EntityType()
                {
                    Id = 1,
                    Name = "Others"
                },
                new EntityType()
                {
                    Id = 2,
                    Name = "Advice Consulting"
                },
                new EntityType()
                {
                    Id = 3,
                    Name = "Workshop class"
                },
                new EntityType()
                {
                    Id = 4,
                    Name = "Online Course"
                },
                new EntityType()
                {
                    Id = 5,
                    Name = "Training Course"
                });
        }
    }
}
