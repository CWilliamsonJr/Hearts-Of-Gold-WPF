namespace Hearts_Of_Gold_WPF.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Hearts_Of_Gold_Entities : DbContext
    {
        public Hearts_Of_Gold_Entities()
            : base("name=Hearts_Of_Gold_Entities")
        {
        }

        public virtual DbSet<Donation_Categories> Donation_Categories { get; set; }
        public virtual DbSet<Donation_Location> Donation_Location { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donation_Categories>()
                .Property(e => e.Categories)
                .IsUnicode(false);

            modelBuilder.Entity<Donation_Categories>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Donation_Categories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donation_Location>()
                .Property(e => e.BusinessName)
                .IsUnicode(false);

            modelBuilder.Entity<Donation_Location>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Donation_Location>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Donation_Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donation_Location>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Donation_Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Item1)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.DonationItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Streetaddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.RequesterID)
                .WillCascadeOnDelete(false);
        }
    }
}
