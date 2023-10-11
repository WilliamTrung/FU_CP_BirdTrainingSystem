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
        public static void AddSlots(this ModelBuilder modelBuilder)
        {
            var slots = new List<Slot>();
            for(int i = 0; i < 4; i++)
            {
                slots.Add(new Slot
                {
                    Id = i+1,
                    StartTime = new TimeSpan(i+8, 0,0),
                    EndTime = new TimeSpan(i+8, 45, 0)
                });
            }
            for (int i = 0; i < 4; i++)
            {
                slots.Add(new Slot
                {
                    Id = i + 5,
                    StartTime = new TimeSpan(i + 13, 0, 0),
                    EndTime = new TimeSpan(i + 13, 45, 0)
                });
            }
            modelBuilder.Entity<Slot>().HasData(slots);
        }
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
