using System;
using EntityFrameworkCore.Jet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityTest
{
    public partial class ModelContext : DbContext
    {
        public virtual DbSet<AsCodes> AsCodes { get; set; }
        public virtual DbSet<AsPipeTypes> AsPipeTypes { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CutterDelays> CutterDelays { get; set; }
        public virtual DbSet<Cutters> Cutters { get; set; }
        public virtual DbSet<CutterSubcategories> CutterSubcategories { get; set; }
        public virtual DbSet<CutterTasks> CutterTasks { get; set; }
        public virtual DbSet<CutterWorks> CutterWorks { get; set; }
        public virtual DbSet<DateLookup> DateLookup { get; set; }
        public virtual DbSet<DefaultSubcategories> DefaultSubcategories { get; set; }
        public virtual DbSet<Delays> Delays { get; set; }
        public virtual DbSet<EventTypes> EventTypes { get; set; }
        public virtual DbSet<HopperCycles> HopperCycles { get; set; }
        public virtual DbSet<HopperStates> HopperStates { get; set; }
        public virtual DbSet<Instance> Instance { get; set; }
        public virtual DbSet<LightLocations> LightLocations { get; set; }
        public virtual DbSet<LightLogEntries> LightLogEntries { get; set; }
        public virtual DbSet<LightLogEntryTypes> LightLogEntryTypes { get; set; }
        public virtual DbSet<Loads> Loads { get; set; }
        public virtual DbSet<LocalizedDelays> LocalizedDelays { get; set; }
        public virtual DbSet<LocalizedRamTasks> LocalizedRamTasks { get; set; }
        public virtual DbSet<LocalizedSubcategories> LocalizedSubcategories { get; set; }
        public virtual DbSet<LocalizedTasks> LocalizedTasks { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Operators> Operators { get; set; }
        public virtual DbSet<OperatorTypes> OperatorTypes { get; set; }
        public virtual DbSet<PipelineConfigurations> PipelineConfigurations { get; set; }
        public virtual DbSet<PipelineDelays> PipelineDelays { get; set; }
        public virtual DbSet<PipelineTasks> PipelineTasks { get; set; }
        public virtual DbSet<PipelineWorks> PipelineWorks { get; set; }
        public virtual DbSet<PipelineWorkTypes> PipelineWorkTypes { get; set; }
        public virtual DbSet<Pipes> Pipes { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ProjectsOperators> ProjectsOperators { get; set; }
        public virtual DbSet<RamTasks> RamTasks { get; set; }
        public virtual DbSet<RegularHopperDelays> RegularHopperDelays { get; set; }
        public virtual DbSet<SlowBellLoggedStates> SlowBellLoggedStates { get; set; }
        public virtual DbSet<StatesLog> StatesLog { get; set; }
        public virtual DbSet<Subcategories> Subcategories { get; set; }
        public virtual DbSet<SubcategoriesUsaceCodes> SubcategoriesUsaceCodes { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Teeth> Teeth { get; set; }
        public virtual DbSet<UsaceCodes> UsaceCodes { get; set; }
        public virtual DbSet<Vessels> Vessels { get; set; }
        public virtual DbSet<VesselTypes> VesselTypes { get; set; }

        // Unable to generate entity type for table 'Jet.PlannableDelays'. Please see the warning messages.
        // Unable to generate entity type for table 'Jet.PlannableRamTasks'. Please see the warning messages.
        // Unable to generate entity type for table 'Jet.PlannableTasks'. Please see the warning messages.
        // Unable to generate entity type for table 'Jet.ProgramSettings'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseJet(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Vit\MainDevelopment\DelayTracker\Branches\Version2.0\Database\DelaysDB.mdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsCodes>(entity =>
            {
                entity.HasKey(e => e.AsCodeId);

                entity.HasIndex(e => e.EventType)
                    .HasName("DelayTypesAsCodes");

                entity.Property(e => e.AsCodeId).HasColumnName("AsCodeID");

                entity.Property(e => e.CodeName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.EventTypeNavigation)
                    .WithMany(p => p.AsCodes)
                    .HasForeignKey(d => d.EventType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DelayTypesAsCodes");
            });

            modelBuilder.Entity<AsPipeTypes>(entity =>
            {
                entity.HasKey(e => e.AsPipeTypeId);

                entity.Property(e => e.AsPipeTypeId).HasColumnName("AsPipeTypeID");

                entity.Property(e => e.AsPipeName).HasMaxLength(255);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.HasIndex(e => e.VesselType)
                    .HasName("VesselTypesCategories");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.VesselTypeNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.VesselType)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("VesselTypesCategories");
            });

            modelBuilder.Entity<CutterDelays>(entity =>
            {
                entity.HasKey(e => e.CutterEvent);

                entity.HasIndex(e => e.CutterEvent)
                    .HasName("DelaysCutterDelayWorks")
                    .IsUnique();

                entity.HasIndex(e => e.CutterWork)
                    .HasName("CutterWorksCutterDelayWorks")
                    .IsUnique();

                entity.Property(e => e.CutterEvent).ValueGeneratedNever();

                entity.HasOne(d => d.CutterEventNavigation)
                    .WithOne(p => p.CutterDelays)
                    .HasForeignKey<CutterDelays>(d => d.CutterEvent)
                    .HasConstraintName("DelaysCutterDelayWorks");

                entity.HasOne(d => d.CutterWorkNavigation)
                    .WithOne(p => p.CutterDelays)
                    .HasForeignKey<CutterDelays>(d => d.CutterWork)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CutterWorksCutterDelayWorks");
            });

            modelBuilder.Entity<Cutters>(entity =>
            {
                entity.HasKey(e => e.CutterId);

                entity.Property(e => e.CutterId).HasColumnName("CutterID");

                entity.Property(e => e.CutterName).HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CutterSubcategories>(entity =>
            {
                entity.HasKey(e => e.CutterSubcategory);

                entity.HasIndex(e => e.CutterSubcategory)
                    .HasName("SubcategoriesCutterSubcategories")
                    .IsUnique();

                entity.Property(e => e.CutterSubcategory).ValueGeneratedNever();

                entity.HasOne(d => d.CutterSubcategoryNavigation)
                    .WithOne(p => p.CutterSubcategories)
                    .HasForeignKey<CutterSubcategories>(d => d.CutterSubcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SubcategoriesCutterSubcategories");
            });

            modelBuilder.Entity<CutterTasks>(entity =>
            {
                entity.HasKey(e => e.CutterEvent);

                entity.HasIndex(e => e.CutterEvent)
                    .HasName("TasksCutterNondelayWorks")
                    .IsUnique();

                entity.HasIndex(e => e.CutterWork)
                    .HasName("CutterWorksCutterNondelayWorks")
                    .IsUnique();

                entity.Property(e => e.CutterEvent).ValueGeneratedNever();

                entity.HasOne(d => d.CutterEventNavigation)
                    .WithOne(p => p.CutterTasks)
                    .HasForeignKey<CutterTasks>(d => d.CutterEvent)
                    .HasConstraintName("TasksCutterNondelayWorks");

                entity.HasOne(d => d.CutterWorkNavigation)
                    .WithOne(p => p.CutterTasks)
                    .HasForeignKey<CutterTasks>(d => d.CutterWork)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CutterWorksCutterNondelayWorks");
            });

            modelBuilder.Entity<CutterWorks>(entity =>
            {
                entity.HasKey(e => e.CutterWorkId);

                entity.HasIndex(e => e.Cutter)
                    .HasName("CuttersCutterWorks");

                entity.HasIndex(e => e.Tooth)
                    .HasName("ToothID");

                entity.Property(e => e.CutterWorkId).HasColumnName("CutterWorkID");

                entity.HasOne(d => d.CutterNavigation)
                    .WithMany(p => p.CutterWorks)
                    .HasForeignKey(d => d.Cutter)
                    .HasConstraintName("CuttersCutterWorks");

                entity.HasOne(d => d.ToothNavigation)
                    .WithMany(p => p.CutterWorks)
                    .HasForeignKey(d => d.Tooth)
                    .HasConstraintName("TeethCutterWorks");
            });

            modelBuilder.Entity<DateLookup>(entity =>
            {
                entity.HasKey(e => e.MyDate);
            });

            modelBuilder.Entity<DefaultSubcategories>(entity =>
            {
                entity.HasKey(e => e.DefaultSubcategoryId);

                entity.HasIndex(e => e.DefaultSubcategoryId)
                    .HasName("SubcategoriesDefaultSubcategories")
                    .IsUnique();

                entity.Property(e => e.DefaultSubcategoryId)
                    .HasColumnName("DefaultSubcategoryID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.DefaultSubcategory)
                    .WithOne(p => p.DefaultSubcategories)
                    .HasForeignKey<DefaultSubcategories>(d => d.DefaultSubcategoryId)
                    .HasConstraintName("SubcategoriesDefaultSubcategories");
            });

            modelBuilder.Entity<Delays>(entity =>
            {
                entity.HasKey(e => e.DelayId);

                entity.HasIndex(e => e.FinishDate)
                    .HasName("Finish");

                entity.HasIndex(e => e.ProjectOperator)
                    .HasName("Projects_OperatorsDelays");

                entity.HasIndex(e => e.StartDate)
                    .HasName("StartIndex");

                entity.HasIndex(e => e.Subcategory)
                    .HasName("SubcategoriesDelays");

                entity.Property(e => e.DelayId).HasColumnName("DelayID");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ProjectOperatorNavigation)
                    .WithMany(p => p.Delays)
                    .HasForeignKey(d => d.ProjectOperator)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Projects_OperatorsDelays");

                entity.HasOne(d => d.SubcategoryNavigation)
                    .WithMany(p => p.Delays)
                    .HasForeignKey(d => d.Subcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SubcategoriesDelays");
            });

            modelBuilder.Entity<EventTypes>(entity =>
            {
                entity.HasKey(e => e.EventTypeId);

                entity.HasIndex(e => e.EventTypeName)
                    .HasName("TypeCode");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.EventTypeName).IsRequired();
            });

            modelBuilder.Entity<HopperCycles>(entity =>
            {
                entity.HasKey(e => e.HopperCycleId);

                entity.HasIndex(e => e.FinishDate)
                    .HasName("FinishDate");

                entity.HasIndex(e => e.ProjectOperator)
                    .HasName("Projects_OperatorsHopperCycles");

                entity.HasIndex(e => e.StartDate)
                    .HasName("StartDate");

                entity.Property(e => e.HopperCycleId).HasColumnName("HopperCycleID");

                entity.Property(e => e.PipeLength).HasDefaultValueSql("0");

                entity.Property(e => e.Tonnage).HasDefaultValueSql("0");

                entity.Property(e => e.Volume).HasDefaultValueSql("0");

                entity.HasOne(d => d.ProjectOperatorNavigation)
                    .WithMany(p => p.HopperCycles)
                    .HasForeignKey(d => d.ProjectOperator)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Projects_OperatorsHopperCycles");
            });

            modelBuilder.Entity<HopperStates>(entity =>
            {
                entity.HasKey(e => e.HopperStateId);

                entity.Property(e => e.HopperStateId).HasColumnName("HopperStateID");

                entity.Property(e => e.StateName).HasMaxLength(255);
            });

            modelBuilder.Entity<Instance>(entity =>
            {
                entity.HasKey(e => e.ChangeDate);

                entity.Property(e => e.Dtversion)
                    .HasColumnName("DTVersion")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<LightLocations>(entity =>
            {
                entity.HasKey(e => e.LightLocationId);

                entity.HasIndex(e => e.Project)
                    .HasName("ProjectsLightLocations");

                entity.Property(e => e.LightLocationId).HasColumnName("LightLocationID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.LightLocations)
                    .HasForeignKey(d => d.Project)
                    .HasConstraintName("ProjectsLightLocations");
            });

            modelBuilder.Entity<LightLogEntries>(entity =>
            {
                entity.HasKey(e => e.LightLogEntryId);

                entity.HasIndex(e => e.EntryType)
                    .HasName("LightLogEntryTypesLightLogEntries");

                entity.HasIndex(e => e.Location)
                    .HasName("LightLocationsLightLogEntries");

                entity.Property(e => e.LightLogEntryId).HasColumnName("LightLogEntryID");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.EntryTypeNavigation)
                    .WithMany(p => p.LightLogEntries)
                    .HasForeignKey(d => d.EntryType)
                    .HasConstraintName("LightLogEntryTypesLightLogEntries");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.LightLogEntries)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("LightLocationsLightLogEntries");
            });

            modelBuilder.Entity<LightLogEntryTypes>(entity =>
            {
                entity.HasKey(e => e.LightLogEntryTypeId);

                entity.Property(e => e.LightLogEntryTypeId).HasColumnName("LightLogEntryTypeID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EntryTypeName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Loads>(entity =>
            {
                entity.HasKey(e => e.LoadId);

                entity.HasIndex(e => e.Project)
                    .HasName("ProjectsLoads");

                entity.Property(e => e.LoadId).HasColumnName("LoadID");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.Loads)
                    .HasForeignKey(d => d.Project)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ProjectsLoads");
            });

            modelBuilder.Entity<LocalizedDelays>(entity =>
            {
                entity.HasKey(e => e.LocalizedEvent);

                entity.HasIndex(e => e.EventLocation)
                    .HasName("LocationsLocalizedDelays");

                entity.HasIndex(e => e.LocalizedEvent)
                    .HasName("DelaysLocalizedDelays")
                    .IsUnique();

                entity.Property(e => e.LocalizedEvent).ValueGeneratedNever();

                entity.HasOne(d => d.EventLocationNavigation)
                    .WithMany(p => p.LocalizedDelays)
                    .HasForeignKey(d => d.EventLocation)
                    .HasConstraintName("LocationsLocalizedDelays");

                entity.HasOne(d => d.LocalizedEventNavigation)
                    .WithOne(p => p.LocalizedDelays)
                    .HasForeignKey<LocalizedDelays>(d => d.LocalizedEvent)
                    .HasConstraintName("DelaysLocalizedDelays");
            });

            modelBuilder.Entity<LocalizedRamTasks>(entity =>
            {
                entity.HasKey(e => e.LocalizedEvent);

                entity.HasIndex(e => e.EventLocation)
                    .HasName("LocationsLocalizedRamTaks");

                entity.HasIndex(e => e.LocalizedEvent)
                    .HasName("RamTasksLocalizedRamTaks")
                    .IsUnique();

                entity.Property(e => e.LocalizedEvent).ValueGeneratedNever();

                entity.HasOne(d => d.EventLocationNavigation)
                    .WithMany(p => p.LocalizedRamTasks)
                    .HasForeignKey(d => d.EventLocation)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("LocationsLocalizedRamTaks");

                entity.HasOne(d => d.LocalizedEventNavigation)
                    .WithOne(p => p.LocalizedRamTasks)
                    .HasForeignKey<LocalizedRamTasks>(d => d.LocalizedEvent)
                    .HasConstraintName("RamTasksLocalizedRamTaks");
            });

            modelBuilder.Entity<LocalizedSubcategories>(entity =>
            {
                entity.HasKey(e => e.LocalizedSubcategory);

                entity.HasIndex(e => e.LocalizedSubcategory)
                    .HasName("SubcategoriesLocalizedSubcategories")
                    .IsUnique();

                entity.Property(e => e.LocalizedSubcategory).ValueGeneratedNever();

                entity.HasOne(d => d.LocalizedSubcategoryNavigation)
                    .WithOne(p => p.LocalizedSubcategories)
                    .HasForeignKey<LocalizedSubcategories>(d => d.LocalizedSubcategory)
                    .HasConstraintName("SubcategoriesLocalizedSubcategories");
            });

            modelBuilder.Entity<LocalizedTasks>(entity =>
            {
                entity.HasKey(e => e.LocalizedEvent);

                entity.HasIndex(e => e.EventLocation)
                    .HasName("LocationsLocalizedTasks");

                entity.HasIndex(e => e.LocalizedEvent)
                    .HasName("TasksLocalizedTasks")
                    .IsUnique();

                entity.Property(e => e.LocalizedEvent).ValueGeneratedNever();

                entity.HasOne(d => d.EventLocationNavigation)
                    .WithMany(p => p.LocalizedTasks)
                    .HasForeignKey(d => d.EventLocation)
                    .HasConstraintName("LocationsLocalizedTasks");

                entity.HasOne(d => d.LocalizedEventNavigation)
                    .WithOne(p => p.LocalizedTasks)
                    .HasForeignKey<LocalizedTasks>(d => d.LocalizedEvent)
                    .HasConstraintName("TasksLocalizedTasks");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName).HasMaxLength(255);
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => e.NoteId);

                entity.HasIndex(e => e.ProjectId)
                    .HasName("ProjectsNotes");

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.Fuel).HasDefaultValueSql("0");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Water).HasDefaultValueSql("0");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ProjectsNotes");
            });

            modelBuilder.Entity<Operators>(entity =>
            {
                entity.HasKey(e => e.OperatorId);

                entity.HasIndex(e => e.OperatorType)
                    .HasName("OperatorTypesOperators");

                entity.Property(e => e.OperatorId).HasColumnName("OperatorID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OperatorIsActive)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScreenIsAutomatic)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.OperatorTypeNavigation)
                    .WithMany(p => p.Operators)
                    .HasForeignKey(d => d.OperatorType)
                    .HasConstraintName("OperatorTypesOperators");
            });

            modelBuilder.Entity<OperatorTypes>(entity =>
            {
                entity.HasKey(e => e.OperatorTypeId);

                entity.Property(e => e.OperatorTypeId).HasColumnName("OperatorTypeID");

                entity.Property(e => e.OperatorTypeName).HasMaxLength(255);
            });

            modelBuilder.Entity<PipelineConfigurations>(entity =>
            {
                entity.HasKey(e => e.PipelineSubcategory);

                entity.HasIndex(e => e.Pipe)
                    .HasName("PipeTypeID");

                entity.HasIndex(e => e.PipelineSubcategory)
                    .HasName("SubcategoriesPipelineConfigurations")
                    .IsUnique();

                entity.HasIndex(e => e.PipelineWorkType)
                    .HasName("WorkTypeID");

                entity.Property(e => e.PipelineSubcategory).ValueGeneratedNever();

                entity.HasOne(d => d.PipeNavigation)
                    .WithMany(p => p.PipelineConfigurations)
                    .HasForeignKey(d => d.Pipe)
                    .HasConstraintName("PipelineTypesPipelineConfigurations");

                entity.HasOne(d => d.PipelineSubcategoryNavigation)
                    .WithOne(p => p.PipelineConfigurations)
                    .HasForeignKey<PipelineConfigurations>(d => d.PipelineSubcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SubcategoriesPipelineConfigurations");

                entity.HasOne(d => d.PipelineWorkTypeNavigation)
                    .WithMany(p => p.PipelineConfigurations)
                    .HasForeignKey(d => d.PipelineWorkType)
                    .HasConstraintName("PipelineWorkTypesPipelineConfigurations");
            });

            modelBuilder.Entity<PipelineDelays>(entity =>
            {
                entity.HasKey(e => e.PipelineEvent);

                entity.HasIndex(e => e.PipelineEvent)
                    .HasName("DelaysPipelineDelayWorks")
                    .IsUnique();

                entity.HasIndex(e => e.PipelineWork)
                    .HasName("PipelineWorksPipelineDelayWorks")
                    .IsUnique();

                entity.Property(e => e.PipelineEvent).ValueGeneratedNever();

                entity.HasOne(d => d.PipelineEventNavigation)
                    .WithOne(p => p.PipelineDelays)
                    .HasForeignKey<PipelineDelays>(d => d.PipelineEvent)
                    .HasConstraintName("DelaysPipelineDelayWorks");

                entity.HasOne(d => d.PipelineWorkNavigation)
                    .WithOne(p => p.PipelineDelays)
                    .HasForeignKey<PipelineDelays>(d => d.PipelineWork)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PipelineWorksPipelineDelayWorks");
            });

            modelBuilder.Entity<PipelineTasks>(entity =>
            {
                entity.HasKey(e => e.PipelineEvent);

                entity.HasIndex(e => e.PipelineEvent)
                    .HasName("TasksPipelineNonDelayWorks")
                    .IsUnique();

                entity.HasIndex(e => e.PipelineWork)
                    .HasName("PipelineWorksPipelineNonDelayWorks")
                    .IsUnique();

                entity.Property(e => e.PipelineEvent).ValueGeneratedNever();

                entity.HasOne(d => d.PipelineEventNavigation)
                    .WithOne(p => p.PipelineTasks)
                    .HasForeignKey<PipelineTasks>(d => d.PipelineEvent)
                    .HasConstraintName("TasksPipelineNonDelayWorks");

                entity.HasOne(d => d.PipelineWorkNavigation)
                    .WithOne(p => p.PipelineTasks)
                    .HasForeignKey<PipelineTasks>(d => d.PipelineWork)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PipelineWorksPipelineNonDelayWorks");
            });

            modelBuilder.Entity<PipelineWorks>(entity =>
            {
                entity.HasKey(e => e.PipelineWorkId);

                entity.Property(e => e.PipelineWorkId).HasColumnName("PipelineWorkID");

                entity.Property(e => e.Unit).HasMaxLength(255);
            });

            modelBuilder.Entity<PipelineWorkTypes>(entity =>
            {
                entity.HasKey(e => e.PipelineWorkTypeId);

                entity.Property(e => e.PipelineWorkTypeId).HasColumnName("PipelineWorkTypeID");

                entity.Property(e => e.WorkType).HasMaxLength(255);
            });

            modelBuilder.Entity<Pipes>(entity =>
            {
                entity.HasKey(e => e.PipeId);

                entity.HasIndex(e => e.PipeType)
                    .HasName("AsPipeTypesPipes");

                entity.Property(e => e.PipeId).HasColumnName("PipeID");

                entity.Property(e => e.PipeName).HasMaxLength(255);

                entity.HasOne(d => d.PipeTypeNavigation)
                    .WithMany(p => p.Pipes)
                    .HasForeignKey(d => d.PipeType)
                    .HasConstraintName("AsPipeTypesPipes");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.HasIndex(e => e.ProjectId)
                    .HasName("ID");

                entity.HasIndex(e => e.Vessel)
                    .HasName("VesselsProjects");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.ProjectIsActive)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProjectName).HasMaxLength(255);

                entity.Property(e => e.ProjectNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.VesselNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.Vessel)
                    .HasConstraintName("VesselsProjects");
            });

            modelBuilder.Entity<ProjectsOperators>(entity =>
            {
                entity.HasKey(e => e.ProjectOperatorId);

                entity.ToTable("Projects_Operators");

                entity.HasIndex(e => e.Operator)
                    .HasName("LevermanIdForeignKey");

                entity.HasIndex(e => e.Project)
                    .HasName("ProjectsProjects_Operators");

                entity.HasIndex(e => e.ProjectOperatorId)
                    .HasName("ID");

                entity.Property(e => e.ProjectOperatorId).HasColumnName("Project_OperatorID");

                entity.Property(e => e.ProjectOperatorIsActive)
                    .HasColumnName("Project_OperatorIsActive")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.OperatorNavigation)
                    .WithMany(p => p.ProjectsOperators)
                    .HasForeignKey(d => d.Operator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LevermanIdForeignKey");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.ProjectsOperators)
                    .HasForeignKey(d => d.Project)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProjectsProjects_Operators");
            });

            modelBuilder.Entity<RamTasks>(entity =>
            {
                entity.HasKey(e => e.RamTaskId);

                entity.HasIndex(e => e.HopperCycle)
                    .HasName("HopperCyclesRamTasks");

                entity.HasIndex(e => e.Subcategory)
                    .HasName("SubcategoriesRamTasks");

                entity.Property(e => e.RamTaskId).HasColumnName("RamTaskID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.HasOne(d => d.HopperCycleNavigation)
                    .WithMany(p => p.RamTasks)
                    .HasForeignKey(d => d.HopperCycle)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HopperCyclesRamTasks");

                entity.HasOne(d => d.SubcategoryNavigation)
                    .WithMany(p => p.RamTasks)
                    .HasForeignKey(d => d.Subcategory)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SubcategoriesRamTasks");
            });

            modelBuilder.Entity<RegularHopperDelays>(entity =>
            {
                entity.HasKey(e => e.RegularDelayId);

                entity.HasIndex(e => e.RegularDelayId)
                    .HasName("RegularDelayID")
                    .IsUnique();

                entity.Property(e => e.RegularDelayId)
                    .HasColumnName("RegularDelayID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.RegularDelay)
                    .WithOne(p => p.RegularHopperDelays)
                    .HasForeignKey<RegularHopperDelays>(d => d.RegularDelayId)
                    .HasConstraintName("DelaysRegularHopperDelays");
            });

            modelBuilder.Entity<SlowBellLoggedStates>(entity =>
            {
                entity.HasKey(e => e.LoggedState);

                entity.HasIndex(e => e.LoggedState)
                    .HasName("StatesLogSlowBellLoggedStates")
                    .IsUnique();

                entity.Property(e => e.LoggedState).ValueGeneratedNever();

                entity.Property(e => e.OverheadDuration).HasDefaultValueSql("0");

                entity.HasOne(d => d.LoggedStateNavigation)
                    .WithOne(p => p.SlowBellLoggedStates)
                    .HasForeignKey<SlowBellLoggedStates>(d => d.LoggedState)
                    .HasConstraintName("StatesLogSlowBellLoggedStates");
            });

            modelBuilder.Entity<StatesLog>(entity =>
            {
                entity.HasKey(e => e.StateLogId);

                entity.HasIndex(e => e.HopperCycle)
                    .HasName("HopperCyclesStatesLog");

                entity.HasIndex(e => e.HopperState)
                    .HasName("HopperStatesStatesLog");

                entity.Property(e => e.StateLogId).HasColumnName("StateLogID");

                entity.HasOne(d => d.HopperCycleNavigation)
                    .WithMany(p => p.StatesLog)
                    .HasForeignKey(d => d.HopperCycle)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HopperCyclesStatesLog");

                entity.HasOne(d => d.HopperStateNavigation)
                    .WithMany(p => p.StatesLog)
                    .HasForeignKey(d => d.HopperState)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HopperStatesStatesLog");
            });

            modelBuilder.Entity<Subcategories>(entity =>
            {
                entity.HasKey(e => e.SubcategoryId);

                entity.HasIndex(e => e.AsCode)
                    .HasName("GroupID");

                entity.HasIndex(e => e.Category)
                    .HasName("CategoryID");

                entity.Property(e => e.SubcategoryId).HasColumnName("SubcategoryID");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SubcategoryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.AsCodeNavigation)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.AsCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AsCodesSubcategories");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoriesSubcategories");
            });

            modelBuilder.Entity<SubcategoriesUsaceCodes>(entity =>
            {
                entity.HasKey(e => e.Subcategory);

                entity.ToTable("Subcategories_UsaceCodes");

                entity.HasIndex(e => e.Subcategory)
                    .HasName("Subcategory")
                    .IsUnique();

                entity.HasIndex(e => e.UsaceCode)
                    .HasName("UsaceCodesSubcategories_UsaceCodes");

                entity.Property(e => e.Subcategory).ValueGeneratedNever();

                entity.HasOne(d => d.SubcategoryNavigation)
                    .WithOne(p => p.SubcategoriesUsaceCodes)
                    .HasForeignKey<SubcategoriesUsaceCodes>(d => d.Subcategory)
                    .HasConstraintName("SubcategoriesSubcategories_UsaceCodes");

                entity.HasOne(d => d.UsaceCodeNavigation)
                    .WithMany(p => p.SubcategoriesUsaceCodes)
                    .HasForeignKey(d => d.UsaceCode)
                    .HasConstraintName("UsaceCodesSubcategories_UsaceCodes");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.HasIndex(e => e.Delay)
                    .HasName("DelaysTasks");

                entity.HasIndex(e => e.FinishDate)
                    .HasName("Finish");

                entity.HasIndex(e => e.StartDate)
                    .HasName("StartIndex");

                entity.HasIndex(e => e.Subcategory)
                    .HasName("SubcategoriesTasks");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.HasOne(d => d.DelayNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Delay)
                    .HasConstraintName("DelaysTasks");

                entity.HasOne(d => d.SubcategoryNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Subcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SubcategoriesTasks");
            });

            modelBuilder.Entity<Teeth>(entity =>
            {
                entity.HasKey(e => e.ToothId);

                entity.Property(e => e.ToothId).HasColumnName("ToothID");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ToothName).HasMaxLength(255);
            });

            modelBuilder.Entity<UsaceCodes>(entity =>
            {
                entity.HasKey(e => e.UsaceCodeId);

                entity.HasIndex(e => e.UsaceCodeName)
                    .HasName("UsaceCodesUsaceCode");

                entity.Property(e => e.UsaceCodeId).HasColumnName("UsaceCodeID");

                entity.Property(e => e.UsaceCodeDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UsaceCodeName)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Vessels>(entity =>
            {
                entity.HasKey(e => e.VesselId);

                entity.HasIndex(e => e.VesselType)
                    .HasName("VesselTypesVessels");

                entity.Property(e => e.VesselId).HasColumnName("VesselID");

                entity.Property(e => e.VesselName).HasMaxLength(255);

                entity.HasOne(d => d.VesselTypeNavigation)
                    .WithMany(p => p.Vessels)
                    .HasForeignKey(d => d.VesselType)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("VesselTypesVessels");
            });

            modelBuilder.Entity<VesselTypes>(entity =>
            {
                entity.HasKey(e => e.VesselTypeId);

                entity.Property(e => e.VesselTypeId).HasColumnName("VesselTypeID");

                entity.Property(e => e.VesselTypeName).HasMaxLength(255);
            });
        }
    }
}
