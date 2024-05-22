using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BasketballProj.Models.DB;

public partial class NbaContext : DbContext
{
    public NbaContext()
    {
    }

    public NbaContext(DbContextOptions<NbaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionType> ActionTypes { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Conference> Conferences { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Matchup> Matchups { get; set; }

    public virtual DbSet<MatchupDetail> MatchupDetails { get; set; }

    public virtual DbSet<MatchupLog> MatchupLogs { get; set; }

    public virtual DbSet<MatchupType> MatchupTypes { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerInTeam> PlayerInTeams { get; set; }

    public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PostSeason> PostSeasons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NBA;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionType>(entity =>
        {
            entity.ToTable("ActionType");

            entity.Property(e => e.ActionTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Jobnumber);

            entity.ToTable("Admin");

            entity.Property(e => e.Jobnumber)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Passwords)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Role).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin_Role");
        });

        modelBuilder.Entity<Conference>(entity =>
        {
            entity.ToTable("Conference");

            entity.Property(e => e.ConferenceId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryCode);

            entity.ToTable("Country");

            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.ToTable("Division");

            entity.Property(e => e.DivisionId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Conference).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Division_Conference");
        });

        modelBuilder.Entity<Matchup>(entity =>
        {
            entity.HasKey(e => e.MatchupId).HasName("PK_Schedule");

            entity.ToTable("Matchup");

            entity.Property(e => e.CurrentQuarter)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Starttime).HasColumnType("datetime");
            entity.Property(e => e.TeamAway).HasColumnName("Team_Away");
            entity.Property(e => e.TeamAwayScore).HasColumnName("Team_Away_Score");
            entity.Property(e => e.TeamHome).HasColumnName("Team_Home");
            entity.Property(e => e.TeamHomeScore).HasColumnName("Team_Home_Score");

            entity.HasOne(d => d.MatchupType).WithMany(p => p.Matchups)
                .HasForeignKey(d => d.MatchupTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_SeasonType");

            entity.HasOne(d => d.Season).WithMany(p => p.Matchups)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matchup_Season");

            entity.HasOne(d => d.TeamAwayNavigation).WithMany(p => p.MatchupTeamAwayNavigations)
                .HasForeignKey(d => d.TeamAway)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Team");

            entity.HasOne(d => d.TeamHomeNavigation).WithMany(p => p.MatchupTeamHomeNavigations)
                .HasForeignKey(d => d.TeamHome)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Team1");
        });

        modelBuilder.Entity<MatchupDetail>(entity =>
        {
            entity.ToTable("MatchupDetail");

            entity.Property(e => e.TeamAwayScore).HasColumnName("Team_Away_Score");
            entity.Property(e => e.TeamHomeScore).HasColumnName("Team_Home_Score");

            entity.HasOne(d => d.Matchup).WithMany(p => p.MatchupDetails)
                .HasForeignKey(d => d.MatchupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchupResult_Schedule");
        });

        modelBuilder.Entity<MatchupLog>(entity =>
        {
            entity.ToTable("MatchupLog");

            entity.Property(e => e.OccurTime)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Remark)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.ActionType).WithMany(p => p.MatchupLogs)
                .HasForeignKey(d => d.ActionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchupLog_ActionType");

            entity.HasOne(d => d.Matchup).WithMany(p => p.MatchupLogs)
                .HasForeignKey(d => d.MatchupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchupLog_Schedule");

            entity.HasOne(d => d.Player).WithMany(p => p.MatchupLogs)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchupLog_Player");

            entity.HasOne(d => d.Team).WithMany(p => p.MatchupLogs)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchupLog_Team");
        });

        modelBuilder.Entity<MatchupType>(entity =>
        {
            entity.HasKey(e => e.MatchupTypeId).HasName("PK_ScheduleType");

            entity.ToTable("MatchupType");

            entity.Property(e => e.MatchupTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PictureInGallery");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Img).HasColumnType("image");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.College)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Height).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Img).HasColumnType("image");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Players)
                .HasForeignKey(d => d.CountryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Player_Country");

            entity.HasOne(d => d.Position).WithMany(p => p.Players)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Player_Position");
        });

        modelBuilder.Entity<PlayerInTeam>(entity =>
        {
            entity.ToTable("PlayerInTeam");

            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ShirtNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerInTeams)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerInTeam_Player");

            entity.HasOne(d => d.Season).WithMany(p => p.PlayerInTeams)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerInTeam_Season");

            entity.HasOne(d => d.Team).WithMany(p => p.PlayerInTeams)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerInTeam_Team");
        });

        modelBuilder.Entity<PlayerStatistic>(entity =>
        {
            entity.Property(e => e.Dffr).HasColumnName("DFFR");
            entity.Property(e => e.Min).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Offr).HasColumnName("OFFR");

            entity.HasOne(d => d.Matchup).WithMany(p => p.PlayerStatistics)
                .HasForeignKey(d => d.MatchupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchupStatistics_Schedule");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerStatistics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchupStatistics_Player");

            entity.HasOne(d => d.Team).WithMany(p => p.PlayerStatistics)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchupStatistics_Team");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.PositionId).ValueGeneratedNever();
            entity.Property(e => e.Abbr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PostSeason>(entity =>
        {
            entity.HasKey(e => new { e.TeamId, e.SeasonId });

            entity.ToTable("PostSeason");

            entity.HasOne(d => d.Season).WithMany(p => p.PostSeasons)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamInPostseason_Season");

            entity.HasOne(d => d.Team).WithMany(p => p.PostSeasons)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamInPostseason_Team");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.ToTable("Season");

            entity.Property(e => e.SeasonId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.Property(e => e.TeamId).ValueGeneratedNever();
            entity.Property(e => e.Abbr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Coach)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Logo).HasColumnType("image");
            entity.Property(e => e.Stadium)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Division).WithMany(p => p.Teams)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Division");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
