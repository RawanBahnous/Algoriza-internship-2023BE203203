using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Models;

namespace Vezeeta.Infrastructure.Data
{
    public class VezeetaDbContext : IdentityDbContext<ApplicationUser>
    {
        public VezeetaDbContext(DbContextOptions<VezeetaDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<TimesAppointment> Times { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<DiscountAppointment> DiscountAppointment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Specialization>()
                 .HasKey(s => s.Id); 

            //1-m Admin - spec / docs / appoin / bookings
            //modelBuilder.Entity<Admin>()
            //    .HasMany(a => a.Specializations)
            //    .WithOne();

            //modelBuilder.Entity<Admin>()
            //    .HasMany(a => a.Doctors)
            //    .WithOne();


            //modelBuilder.Entity<Admin>()
            //    .HasMany(a => a.Discounts)
            //    .WithOne();

            //modelBuilder.Entity<Admin>()
            //    .HasMany(a => a.BookingAppointments)
            //    .WithOne();

            //1-M spec - docs

            modelBuilder.Entity<Specialization>()
                .HasMany(s => s.Doctors)
                .WithOne(d => d.Specialize)
                .HasForeignKey(d => d.SpecializeId);


            //1-M appointment - times

            //modelBuilder.Entity<Appointment>()
            //    .HasMany(a => a.Time)
            //    .WithOne(t => t.Appointment)
            //    .HasForeignKey(t => t.AppointmentId);

            ////1-M patinnt - discount / bookings


            //modelBuilder.Entity<Patient>()
            //    .HasMany(p => p.Discounts)
            //    .WithOne(d => d.Patient);

            //modelBuilder.Entity<Patient>().HasMany(p => p.Bookings).WithOne(b => b.Patient);

            ////1-M  docs -appo/bookings/


            //modelBuilder.Entity<Doctor>()
            //    .HasMany(d => d.Appointments)
            //    .WithOne(a => a.Doctor);

            modelBuilder.Entity<Discount>()
                .Property(d => d.Value)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            ////M-M disc-appoin

            //modelBuilder.Entity<Appointment>()
            //    .HasMany(p => p.Discounts)
            //    .WithMany(d => d.Appointments)
            //    .UsingEntity<Appointment>(j => j.ToTable("AppointmentDiscount"));

        }

    }
}

