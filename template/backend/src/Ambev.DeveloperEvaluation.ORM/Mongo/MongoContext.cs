using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Ambev.DeveloperEvaluation.ORM.Mongo;

public class MongoContext : DbContext
{
    public DbSet<Sale> Sales { get; init; }

    public MongoContext(DbContextOptions<MongoContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Sale>().ToCollection("sales");
    }
}