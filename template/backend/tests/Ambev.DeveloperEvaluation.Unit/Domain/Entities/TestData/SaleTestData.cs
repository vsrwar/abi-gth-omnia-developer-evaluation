using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;
using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// The generated sale will have valid:
    /// - _id (ObjectId.GenerateNewId())
    /// - Number (between 0 and 99999)
    /// - UserId (Guid.NewGuid())
    /// - Branch (single word)
    /// - Products (1 to 5)
    /// </summary>
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s._id, _ => ObjectId.GenerateNewId())
        .RuleFor(s => s.Number, f => f.Random.Number(0, 99999))
        .RuleFor(s => s.UserId, _ => Guid.NewGuid())
        .RuleFor(s => s.Branch, f => f.Address.City())
        .RuleFor(s => s.Products, f => SaleProductFaker?.Generate(f.Random.Int(1, 5)));

    private static readonly Faker<SaleProduct> SaleProductFaker = new Faker<SaleProduct>()
        .RuleFor(sp => sp.ProductId, _ => Guid.NewGuid())
        .RuleFor(sp => sp.Quantity, f => f.Random.Int(1, 20))
        .RuleFor(sp => sp.Price, f => f.Random.Decimal(0, 9999));

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale()
    {
        return SaleFaker.Generate();
    }

    /// <summary>
    /// Generates an invalid Sale with empty user id.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateEmptyUserIdSale()
    {
        return new Faker<Sale>()
            .RuleFor(s => s._id, _ => ObjectId.GenerateNewId())
            .RuleFor(s => s.Number, f => f.Random.Number(0, 99999))
            .RuleFor(s => s.UserId, _ => Guid.Empty)
            .RuleFor(s => s.Branch, f => f.Address.City())
            .RuleFor(s => s.Products, f => SaleProductFaker?.Generate(f.Random.Int(1, 5)))
        .Generate();
    }

    /// <summary>
    /// Generates an invalid Sale with empty branch.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    /// <param name="branchLength">Length of the branch name, default is 0 (empty branch)</param>
    public static Sale GenerateBranchSale(int branchLength = 0)
    {
        return branchLength is 0
            ? new Faker<Sale>()
                .RuleFor(s => s._id, _ => ObjectId.GenerateNewId())
                .RuleFor(s => s.Number, f => f.Random.Number(0, 99999))
                .RuleFor(s => s.UserId, _ => Guid.Empty)
                .RuleFor(s => s.Products, f => SaleProductFaker?.Generate(f.Random.Int(1, 5)))
                .Generate()
            : new Faker<Sale>()
                .RuleFor(s => s._id, _ => ObjectId.GenerateNewId())
                .RuleFor(s => s.Number, f => f.Random.Number(0, 99999))
                .RuleFor(s => s.UserId, _ => Guid.Empty)
                .RuleFor(s => s.Branch, _ => "".PadLeft(branchLength, 'x'))
                .RuleFor(s => s.Products, f => SaleProductFaker?.Generate(f.Random.Int(1, 5)))
                .Generate();
    }

    /// <summary>
    /// Generates an invalid Sale no products.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateSaleWithNoProducts()
    {
        return new Faker<Sale>()
            .RuleFor(s => s._id, _ => ObjectId.GenerateNewId())
            .RuleFor(s => s.Number, f => f.Random.Number(0, 99999))
            .RuleFor(s => s.UserId, _ => Guid.NewGuid())
            .RuleFor(s => s.Branch, f => f.Address.City())
            .RuleFor(s => s.Products, _ => new List<SaleProduct>())
        .Generate();
    }

    /// <summary>
    /// Generates a valid Sale number with randomized data.
    /// </summary>
    /// <returns>A valid Sale number with randomly generated number.</returns>
    public static int GenerateValidSaleNumber()
    {
        return new Faker().Random.Number(0, 99999);
    }

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// Will have a single product with quantity equal to equalProductsQuantity passed by param.
    /// </summary>
    /// <param name="equalProductsQuantity">Quantity of equal products that sale should have</param>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSaleWithEqualProducts(int equalProductsQuantity)
    {
        return new Faker<Sale>()
            .RuleFor(s => s._id, _ => ObjectId.GenerateNewId())
            .RuleFor(s => s.Number, f => f.Random.Number(0, 99999))
            .RuleFor(s => s.UserId, _ => Guid.NewGuid())
            .RuleFor(s => s.Branch, f => f.Address.City())
            .RuleFor(s => s.Products, _ => new Faker<SaleProduct>()
                .RuleFor(sp => sp.ProductId, _ => Guid.NewGuid())
                .RuleFor(sp => sp.Quantity, _ => equalProductsQuantity)
                .RuleFor(sp => sp.Price, f => f.Random.Decimal(0, 9999)).Generate(1)
            )
            .Generate();
    }
}