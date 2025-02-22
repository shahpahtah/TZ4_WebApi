using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DbModel;

namespace TZ4.Data.EF
{
    public class DbContextUser : DbContext
    {
        public DbSet<UserDto> Users { get; set; }

        public DbContextUser(DbContextOptions<DbContextUser> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration()); // Используем отдельный класс конфигурации
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<UserDto>
    {
        public void Configure(EntityTypeBuilder<UserDto> builder)
        {
            builder.HasKey(u => u.Id); // Primary Key
            builder.Property(u => u.LastName)
                .IsRequired() // NOT NULL в базе данных
                .HasMaxLength(30);

            builder.Property(u => u.FirstName)
                .IsRequired() // NOT NULL в базе данных
                .HasMaxLength(30);

            builder.Property(u => u.Email)
                .HasMaxLength(60);
            builder.HasIndex(u => u.Email).IsUnique(); // Уникальный индекс на email

            builder.Property(u => u.DateOfBirth)
                .HasColumnType("datetime2"); // Или "date", если используешь DateOnly
        }
    }
}