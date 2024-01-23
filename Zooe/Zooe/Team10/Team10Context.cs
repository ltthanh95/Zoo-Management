using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zooe.Team10
{
    public partial class Team10Context : IdentityDbContext
    {
        public Team10Context(string connectionString)
        {
        }

        public Team10Context(DbContextOptions<Team10Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Exhibit> Exhibit { get; set; }
        public virtual DbSet<GiftShop> GiftShop { get; set; }
        public virtual DbSet<ItemPurchase> ItemPurchase { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<PrivateEvent> PrivateEvent { get; set; }
        public virtual DbSet<PrivateEventPurchase> PrivateEventPurchase { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<TicketPurchase> TicketPurchase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=project.cwcrxvcwutfi.us-east-2.rds.amazonaws.com;user=thanh;password=passt;database=Team10", x => x.ServerVersion("5.7.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasIndex(e => e.ExhibitId)
                    .HasName("fk_Animal_Exhibit1_idx");

                entity.Property(e => e.AnimalId)
                    .HasColumnName("Animal_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExhibitId)
                    .HasColumnName("Exhibit_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Gender).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastCheckup)
                    .HasColumnName("Last_Checkup")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .HasColumnName("Short_Description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Weight).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.Exhibit)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.ExhibitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Animal_Exhibit1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("Phone_Number")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnName("Street_Name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipCode)
                    .HasColumnName("Zip_Code")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("Department_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("Department_Name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("fk_Public Events_Department1_idx");

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("Image_URL")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Public Events_Department1");
            });

            modelBuilder.Entity<Exhibit>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("fk_EXHIBIT_Department1_idx");

                entity.Property(e => e.ExhibitId)
                    .HasColumnName("Exhibit_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnimalId)
                    .HasColumnName("Animal_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExhibitHabitat)
                    .IsRequired()
                    .HasColumnName("Exhibit_Habitat")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("Image_URL")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Exhibit)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EXHIBIT_Department1");
            });

            modelBuilder.Entity<GiftShop>(entity =>
            {
                entity.HasKey(e => e.ShopId)
                    .HasName("PRIMARY");

                entity.ToTable("Gift_Shop");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("fk_Shop_Department1_idx");

                entity.Property(e => e.ShopId)
                    .HasColumnName("Shop_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("Image_URL")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasColumnName("Shop_Name")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.GiftShop)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Shop_Department1");
            });

            modelBuilder.Entity<ItemPurchase>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PRIMARY");

                entity.ToTable("Item_Purchase");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("Customer_ID_idx");

                entity.HasIndex(e => e.ItemId)
                    .HasName("Item_ID_idx");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("Transaction_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("Item_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("Purchase_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.TotalCost).HasColumnName("Total_Cost");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ItemPurchase)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Item_Purchase_customer1");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemPurchase)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Item_Purchase_item1");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ShopId)
                    .HasName("Shop_ID_idx");

                entity.Property(e => e.ItemId)
                    .HasColumnName("Item_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("Image_URL")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShopId)
                    .HasColumnName("Shop_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StockCount)
                    .HasColumnName("Stock_Count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Shop_ID");
            });

            modelBuilder.Entity<PrivateEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PRIMARY");

                entity.ToTable("Private_Event");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("fk_Private Events_Department1_idx");

                entity.HasIndex(e => e.EventId)
                    .HasName("Event_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EventDate)
                    .HasColumnName("Event_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasColumnName("Event_Type")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GuestCapacity)
                    .HasColumnName("Guest_Capacity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("Image_URL")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsBooked)
                    .HasColumnName("Is_Booked")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PrivateEvent)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Private_Event_Department1");
            });

            modelBuilder.Entity<PrivateEventPurchase>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PRIMARY");

                entity.ToTable("Private_Event_Purchase");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("Customer_ID_idx");

                entity.HasIndex(e => e.EventId)
                    .HasName("Event_ID_idx");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("Transaction_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsValid)
                    .HasColumnName("Is_Valid")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.PassId)
                    .HasColumnName("Pass_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("Purchase_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalCost)
                    .HasColumnName("Total_Cost")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PrivateEventPurchase)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Private_Event_Purchase_Customer1");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.PrivateEventPurchase)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Private_Event_Purchase_Event1");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("fk_STAFF_Department1_idx");

                entity.HasIndex(e => e.StaffId)
                    .HasName("Staff_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.StaffId)
                    .HasColumnName("Staff_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("Email_Address")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomeAddress)
                    .IsRequired()
                    .HasColumnName("Home_Address")
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("Job_Title")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Department_ID");
            });

            modelBuilder.Entity<TicketPurchase>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PRIMARY");

                entity.ToTable("Ticket_Purchase");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("Customer_ID_idx");

                entity.HasIndex(e => e.TicketId)
                    .HasName("Ticket_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.TicketId)
                    .HasColumnName("Ticket_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("Expiration_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsValid)
                    .HasColumnName("Is_Valid")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("Purchase_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("Transaction_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TicketPurchase)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_ID");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("Name")
                    .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedName")
                    .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasName("RoleNameIndex");

                b.ToTable("AspNetRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("ClaimType")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("ClaimValue")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("RoleId")
                    .IsRequired()
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.Property<int>("AccessFailedCount")
                    .HasColumnType("int");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("Email")
                    .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                    .HasMaxLength(256);

                b.Property<bool>("EmailConfirmed")
                    .HasColumnType("tinyint(1)");

                b.Property<bool>("LockoutEnabled")
                    .HasColumnType("tinyint(1)");

                b.Property<DateTimeOffset?>("LockoutEnd")
                    .HasColumnType("datetime(6)");

                b.Property<string>("NormalizedEmail")
                    .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedUserName")
                    .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                    .HasMaxLength(256);

                b.Property<string>("PasswordHash")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("PhoneNumber")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<bool>("PhoneNumberConfirmed")
                    .HasColumnType("tinyint(1)");

                b.Property<string>("SecurityStamp")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<bool>("TwoFactorEnabled")
                    .HasColumnType("tinyint(1)");

                b.Property<string>("UserName")
                    .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedEmail")
                    .HasName("EmailIndex");

                b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasName("UserNameIndex");

                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("ClaimType")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("ClaimValue")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.Property<string>("LoginProvider")
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.Property<string>("ProviderKey")
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.Property<string>("ProviderDisplayName")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.Property<string>("RoleId")
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.Property<string>("LoginProvider")
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.Property<string>("Name")
                    .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                b.Property<string>("Value")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
