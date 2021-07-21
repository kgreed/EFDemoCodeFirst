using System;
using System.Data.Entity;
using System.Data.Common;

using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.ExpressApp.EF.DesignTime;
using DevExpress.ExpressApp.Design;
using System.Data.Entity.Infrastructure;

namespace EFDemo.Module.Data {
    public class EFDemoDbContextInitializer : DbContextTypesInfoInitializerBase {
        protected override DbContext CreateDbContext() {
            DbContextInfo contextInfo = new DbContextInfo(typeof(EFDemoDbContext), new DbProviderInfo(providerInvariantName: "System.Data.SqlClient", providerManifestToken: "2008"));
            return contextInfo.CreateInstance();
        }
    }
    [TypesInfoInitializer(typeof(EFDemoDbContextInitializer))]
    public class EFDemoDbContext : DbContext {
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<FileData>().ToTable("FileData");
			modelBuilder.Entity<Person>().ToTable("Parties_Person");
			modelBuilder.Entity<Employee>().ToTable("Parties_Employee");
			modelBuilder.Entity<Organization>().ToTable("Parties_Organization");
			modelBuilder.Entity<PortfolioFileData>().ToTable("FileAttachments_PortfolioFileData");
			modelBuilder.Entity<DemoTask>().ToTable("Tasks_DemoTask");
			modelBuilder.Entity<Analysis>().ToTable("Analysis");
			modelBuilder.Entity<ReportDataV2>().ToTable("ReportDataV2");
			modelBuilder.Entity<ModuleInfo>().ToTable("ModulesInfo");

			modelBuilder.Entity<DemoTask>().HasMany(t => t.Employees).WithMany(c => c.Tasks).Map(mc => {
				mc.ToTable("DemoTasks_Employees");
				mc.MapLeftKey("Tasks_ID");
				mc.MapRightKey("Employees_ID");
			});

			modelBuilder.Entity<Department>().HasMany(d => d.Positions).WithMany(p => p.Departments).Map(mc => {
				mc.ToTable("Departments_Positions");
				mc.MapLeftKey("Departments_ID");
				mc.MapRightKey("Positions_ID");
			});

			modelBuilder.Entity<Event>().HasMany(e => e.Resources).WithMany(r => r.Events).Map(mc => {
				mc.ToTable("Events_Resources");
				mc.MapLeftKey("Events_ID");
				mc.MapRightKey("Resources_Key");
			});

			modelBuilder.Entity<PermissionPolicyUser>().HasMany(u => u.Roles).WithMany(r => r.Users).Map(mc => {
				mc.ToTable("Users_Roles");
				mc.MapLeftKey("Users_ID");
				mc.MapRightKey("Roles_ID");
			});

            //modelBuilder.Entity<Role>().HasMany(r => r.ChildRoles).WithMany(r => r.ParentRoles).Map(mc => {
            //	mc.ToTable("Roles_Roles");
            //	mc.MapLeftKey("ParentRoles_ID");
            //	mc.MapRightKey("ChildRoles_ID");
            //});

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.Portfolio)
                .WithOptional(p => p.Resume)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Party>()
                .HasMany(r => r.PhoneNumbers)
                .WithOptional(p => p.Party)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PermissionPolicyRoleBase>()
               .HasMany(r => r.TypePermissions)
               .WithOptional(p => p.Role)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<PermissionPolicyRoleBase>()
               .HasMany(r => r.NavigationPermissions)
               .WithOptional(p => p.Role)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<PermissionPolicyTypePermissionObject>()
               .HasMany(r => r.MemberPermissions)
               .WithOptional(p => p.TypePermissionObject)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<PermissionPolicyTypePermissionObject>()
               .HasMany(r => r.ObjectPermissions)
               .WithOptional(p => p.TypePermissionObject)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<ModelDifference>()
              .HasMany(r => r.Aspects)
              .WithOptional(p => p.Owner)
              .WillCascadeOnDelete(true);
        }

        public EFDemoDbContext(String connectionString)
			: base(connectionString) {
		}
		public EFDemoDbContext(DbConnection connection)
			: base(connection, false) {
		}
        public EFDemoDbContext() { 
        }

        public DbSet<Address> Addresses { get; set; }
		public DbSet<Analysis> Analysis { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<FileAttachment> FileAttachments { get; set; }
		public DbSet<FileData> FileData { get; set; }
		public DbSet<HCategory> HCategories { get; set; }
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
		public DbSet<Note> Notes { get; set; }
		public DbSet<Party> Parties { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<PhoneNumber> PhoneNumbers { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<ReportDataV2> ReportData { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Resume> Resumes { get; set; }
		public DbSet<PermissionPolicyRole> Roles { get; set; }
		public DbSet<State> States { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<PermissionPolicyUser> Users { get; set; }
		public DbSet<ModelDifference> ModelDifferences { get; set; }
		public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
	}
}
