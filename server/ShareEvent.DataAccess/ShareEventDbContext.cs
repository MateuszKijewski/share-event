using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareEvent.Models.Entities;

namespace ShareEvent.DataAccess
{
    public class ShareEventDbContext : DbContext
    {
        public ShareEventDbContext(DbContextOptions<ShareEventDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TicketType>()
                .HasOne(tt => tt.Event)
                .WithMany(e => e.TicketTypes)
                .HasForeignKey(tt => tt.EventId);

            builder.Entity<Reservation>()
                .HasOne(r => r.TicketType)
                .WithMany(tt => tt.Reservations)
                .HasForeignKey(r => r.TicketTypeId);
        }
    }
}
