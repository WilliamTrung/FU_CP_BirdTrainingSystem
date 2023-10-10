using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Context
{
    public static class AddModels
    {
        public static void AddMembershipModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipRank>().HasData(
                new MembershipRank
                {
                    Id = 1,
                    Name = "Standard",
                    Discount = 0,
                    Requirement = 0,
                },
                new MembershipRank
                {
                    Id= 2,
                    Name = "Gold",
                    Discount = 0.1f,
                    Requirement = 50*1000*1000,
                },
                new MembershipRank
                {
                    Id = 3,
                    Name = "Platinum",
                    Discount = 0.2f,
                    Requirement = 100*1000*1000
                });
        }
    }
}
