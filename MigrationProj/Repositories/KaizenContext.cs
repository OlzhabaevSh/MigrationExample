namespace MigrationProj.Repositories
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KaizenContext : DbContext
    {
        public KaizenContext()
            : base("name=KaizenContext")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrgUnits> OrgUnits { get; set; }
        public virtual DbSet<OrgUnitTypes> OrgUnitTypes { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Sectors> Sectors { get; set; }
        public virtual DbSet<StaffLists> StaffLists { get; set; }
        public virtual DbSet<StaffRooms> StaffRooms { get; set; }
        public virtual DbSet<StaffRoomTypes> StaffRoomTypes { get; set; }
        public virtual DbSet<WorkSchedules> WorkSchedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Positions>()
                .HasMany(e => e.Employees)
                .WithMany(e => e.Positions)
                .Map(m => m.ToTable("PositionEmployees").MapLeftKey("Position_Id").MapRightKey("Employee_Id"));

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.StaffLists)
                .WithRequired(e => e.Employees)
                .HasForeignKey(e => e.EmployeeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrgUnits>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.OrgUnits)
                .HasForeignKey(e => e.OrgUnitId);

            modelBuilder.Entity<OrgUnits>()
                .HasMany(e => e.OrgUnits1)
                .WithOptional(e => e.OrgUnits2)
                .HasForeignKey(e => e.OrgUnitId);

            modelBuilder.Entity<OrgUnits>()
                .HasMany(e => e.StaffLists)
                .WithRequired(e => e.OrgUnits)
                .HasForeignKey(e => e.OrgUnitId);

            modelBuilder.Entity<OrgUnitTypes>()
                .HasMany(e => e.OrgUnits)
                .WithRequired(e => e.OrgUnitTypes)
                .HasForeignKey(e => e.OrgUnitTypeId);

            modelBuilder.Entity<Positions>()
                .HasMany(e => e.StaffLists)
                .WithRequired(e => e.Positions)
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<Sectors>()
                .HasMany(e => e.StaffLists)
                .WithOptional(e => e.Sectors)
                .HasForeignKey(e => e.SectorId);

            modelBuilder.Entity<StaffLists>()
                .HasMany(e => e.WorkSchedules)
                .WithRequired(e => e.StaffLists)
                .HasForeignKey(e => e.StaffListId);

            modelBuilder.Entity<StaffRooms>()
                .HasMany(e => e.StaffLists)
                .WithOptional(e => e.StaffRooms)
                .HasForeignKey(e => e.StaffRoomId);

            modelBuilder.Entity<StaffRoomTypes>()
                .HasMany(e => e.StaffRooms)
                .WithRequired(e => e.StaffRoomTypes)
                .HasForeignKey(e => e.TypeId);
        }
    }
}
