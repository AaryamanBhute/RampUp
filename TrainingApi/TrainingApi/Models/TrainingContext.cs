using Microsoft.EntityFrameworkCore;

namespace TrainingApi.Models;

public class TrainingContext : DbContext
{
    public TrainingContext(DbContextOptions<TrainingContext> options)
        : base(options)
    {
    }

    public DbSet<TrainingItem> TrainingItems { get; set; } = null!;
}