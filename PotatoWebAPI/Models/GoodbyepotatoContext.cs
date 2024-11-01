using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PotatoWebAPI.Models;

public partial class GoodbyepotatoContext : DbContext
{
    public GoodbyepotatoContext(DbContextOptions<GoodbyepotatoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessoriesList> AccessoriesLists { get; set; }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterAccessorie> CharacterAccessories { get; set; }

    public virtual DbSet<CharacterItem> CharacterItems { get; set; }

    public virtual DbSet<DailyHealthRecord> DailyHealthRecords { get; set; }

    public virtual DbSet<DailyTask> DailyTasks { get; set; }

    public virtual DbSet<DailyTaskRecord> DailyTaskRecords { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<RoomAccessory> RoomAccessories { get; set; }

    public virtual DbSet<WeeklyHealthRecord> WeeklyHealthRecords { get; set; }

    public virtual DbSet<WeightRecord> WeightRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessoriesList>(entity =>
        {
            entity.HasKey(e => e.PCode).HasName("PK__Accessor__F54C4371E28AF4A7");

            entity.ToTable("AccessoriesList");

            entity.Property(e => e.PCode).HasColumnName("P_Code");
            entity.Property(e => e.PActive).HasColumnName("P_Active");
            entity.Property(e => e.PClass)
                .HasMaxLength(5)
                .HasColumnName("P_Class");
            entity.Property(e => e.PImageAll)
                .HasMaxLength(50)
                .HasColumnName("P_ImageAll");
            entity.Property(e => e.PImageShop)
                .HasMaxLength(50)
                .HasColumnName("P_ImageShop");
            entity.Property(e => e.PLevel).HasColumnName("P_Level");
            entity.Property(e => e.PName)
                .HasMaxLength(30)
                .HasColumnName("P_Name");
            entity.Property(e => e.PPrice).HasColumnName("P_Price");
            entity.Property(e => e.PReviewStatus)
                .HasMaxLength(5)
                .HasDefaultValue("???")
                .HasColumnName("P_ReviewStatus");
        });

        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.AAccount).HasName("PK__Administ__D640633E268F456E");

            entity.ToTable("Administrator");

            entity.Property(e => e.AAccount)
                .HasMaxLength(30)
                .HasColumnName("A_Account");
            entity.Property(e => e.APassword)
                .HasMaxLength(30)
                .HasColumnName("A_Password");
            entity.Property(e => e.MAdministrator).HasColumnName("M_Administrator");
            entity.Property(e => e.MDailyTask).HasColumnName("M_DailyTask");
            entity.Property(e => e.MProduct).HasColumnName("M_Product");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.Property(e => e.RoleId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__Characte__A9FDEC1243760B71");

            entity.ToTable("Character");

            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.Account).HasMaxLength(30);
            entity.Property(e => e.Environment).HasDefaultValue(0);
            entity.Property(e => e.Experience).HasDefaultValue(80);
            entity.Property(e => e.Height).HasColumnType("decimal(4, 1)");
            entity.Property(e => e.Level).HasDefaultValue(1);
            entity.Property(e => e.LivingStatus)
                .HasMaxLength(10)
                .HasDefaultValue("??");
            entity.Property(e => e.MoveInDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MoveOutDate)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Weight).HasColumnType("decimal(4, 1)");
        });

        modelBuilder.Entity<CharacterAccessorie>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__Characte__A9FDEC1226DC50B9");

            entity.ToTable("CharacterAccessorie");

            entity.Property(e => e.CId)
                .ValueGeneratedNever()
                .HasColumnName("C_ID");
            entity.Property(e => e.Head).HasDefaultValue(0);
            entity.Property(e => e.Lower).HasDefaultValue(0);
            entity.Property(e => e.Upper).HasDefaultValue(0);
        });

        modelBuilder.Entity<CharacterItem>(entity =>
        {
            entity.HasKey(e => new { e.Account, e.PCode }).HasName("PK__Characte__BF976870A7B5989E");

            entity.ToTable("CharacterItem");

            entity.Property(e => e.Account).HasMaxLength(30);
            entity.Property(e => e.PCode).HasColumnName("P_Code");
        });

        modelBuilder.Entity<DailyHealthRecord>(entity =>
        {
            entity.HasKey(e => new { e.CId, e.HrecordDate }).HasName("PK__DailyHea__B1752E4FF4705BF1");

            entity.ToTable("DailyHealthRecord");

            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.HrecordDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("HRecordDate");
            entity.Property(e => e.Mood).HasMaxLength(10);
            entity.Property(e => e.Sleep).HasColumnType("datetime");
        });

        modelBuilder.Entity<DailyTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__DailyTas__7C6949D10DE80869");

            entity.ToTable("DailyTask");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.TReviewStatus)
                .HasMaxLength(5)
                .HasDefaultValue("???")
                .HasColumnName("T_ReviewStatus");
            entity.Property(e => e.TaskName).HasMaxLength(50);
        });

        modelBuilder.Entity<DailyTaskRecord>(entity =>
        {
            entity.HasKey(e => new { e.CId, e.TrecordDate }).HasName("PK__DailyTas__F9F4A8E41FFDEF30");

            entity.ToTable("DailyTaskRecord");

            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.TrecordDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("TRecordDate");
            entity.Property(e => e.T1completed).HasColumnName("T1Completed");
            entity.Property(e => e.T1name)
                .HasMaxLength(50)
                .HasColumnName("T1Name");
            entity.Property(e => e.T2completed).HasColumnName("T2Completed");
            entity.Property(e => e.T2name)
                .HasMaxLength(50)
                .HasColumnName("T2Name");
            entity.Property(e => e.T3completed).HasColumnName("T3Completed");
            entity.Property(e => e.T3name)
                .HasMaxLength(50)
                .HasColumnName("T3Name");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackNo).HasName("PK__Feedback__6A4BC46D72BE2F20");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackNo).HasColumnName("FeedbackNO");
            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.ProActive).HasColumnName("Pro_Active");
            entity.Property(e => e.ProContent)
                .HasMaxLength(500)
                .HasColumnName("Pro_Content");
            entity.Property(e => e.ProDate)
                .HasColumnType("datetime")
                .HasColumnName("Pro_Date");
            entity.Property(e => e.Submitted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<PasswordResetRequest>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Token).HasMaxLength(512);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Account).HasName("PK__Player__B0C3AC47028B9E72");

            entity.ToTable("Player");

            entity.Property(e => e.Account).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.Password).HasMaxLength(150);
            entity.Property(e => e.Token).HasMaxLength(100);
        });

        modelBuilder.Entity<RoomAccessory>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__RoomAcce__A9FDEC120FC32C66");

            entity.Property(e => e.CId)
                .ValueGeneratedNever()
                .HasColumnName("C_ID");
            entity.Property(e => e.Bed).HasDefaultValue(0);
            entity.Property(e => e.Bookcase).HasDefaultValue(0);
            entity.Property(e => e.Chair).HasDefaultValue(0);
            entity.Property(e => e.Desk).HasDefaultValue(0);
            entity.Property(e => e.Plant).HasDefaultValue(0);
        });

        modelBuilder.Entity<WeeklyHealthRecord>(entity =>
        {
            entity.HasKey(e => new { e.CId, e.WrecordDate }).HasName("PK__WeeklyHe__8BF6176F4EA103BF");

            entity.ToTable("WeeklyHealthRecord");

            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.WrecordDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("WRecordDate");
        });

        modelBuilder.Entity<WeightRecord>(entity =>
        {
            entity.HasKey(e => new { e.CId, e.WRecordDate }).HasName("PK__WeightRe__2CF18179E797E449");

            entity.ToTable("WeightRecord");

            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.WRecordDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("W_RecordDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
