using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Ambev.DeveloperEvaluation.ORM.Mongo;

public class MongoContext : DbContext
{
    public DbSet<Sale> Sales { get; init; }

    public MongoContext(DbContextOptions options) : base(options)
    {
    }
    
    public static MongoContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<MongoContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Sale>().ToCollection("sales");
    }
}