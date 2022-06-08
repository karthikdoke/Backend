using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlightBooking.Usermodel
{
    public partial class F_BookingContext : DbContext
    {
        public F_BookingContext()
        {
        }

        public F_BookingContext(DbContextOptions<F_BookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingFlight> BookingFlight { get; set; }
        public virtual DbSet<FlightsSerach> FlightsSerach { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CTSDOTNET153;Database=F_Booking;User Id=sa;Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingFlight>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("Booking_Flight");

                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.Destination)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NonVeg)
                    .HasColumnName("Non_Veg")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassAge).HasColumnName("pass_Age");

                entity.Property(e => e.PassName)
                    .IsRequired()
                    .HasColumnName("Pass_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.Pnr).HasColumnName("PNR");

                entity.Property(e => e.SelectsSeats)
                    .IsRequired()
                    .HasColumnName("Selects_Seats")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UEmail)
                    .IsRequired()
                    .HasColumnName("U_Email")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Veg)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlightsSerach>(entity =>
            {
                entity.HasKey(e => e.FlightNo);

                entity.ToTable("Flights_Serach");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DicountPrice)
                    .HasColumnName("Dicount_price")
                    .HasColumnType("money");

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasColumnName("End_Time")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FDate)
                    .IsRequired()
                    .HasColumnName("F_Date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FTime)
                    .IsRequired()
                    .HasColumnName("F_Time")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlightName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Oneway)
                    .HasColumnName("oneway")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.OnewayPrice)
                    .HasColumnName("oneway_price")
                    .HasColumnType("money");

                entity.Property(e => e.RoundTrip)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RoundtripPrice)
                    .HasColumnName("Roundtrip_price")
                    .HasColumnType("money");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });
        }
    }
}
