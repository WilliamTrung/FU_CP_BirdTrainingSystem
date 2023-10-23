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
        public static void AddWorkshopDetailTemplate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkshopDetailTemplate>(entity =>
            {
                entity.ToTable("WorkshopDetailTemplate");

                entity.Property(e => e.Detail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopDetailTemplates)
                    .HasForeignKey(d => d.WorkshopId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(d => d.WorkshopClassDetails)
                    .WithOne(p => p.WorkshopDetailTemplate)
                    .HasForeignKey(d => d.DetailId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
