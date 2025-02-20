using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated products will have valid:
    /// - Title (using lorem sentence)
    /// - Price (between 0 and 99999)
    /// - Description (using lorem paragraphs)
    /// - Category (single word)
    /// - Image (using internet Url)
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(p => p.Title, f => f.Lorem.Sentence())
        .RuleFor(p => p.Price, f => f.Random.Decimal(0, 99999))
        .RuleFor(p => p.Description, f => f.Lorem.Paragraphs(2))
        .RuleFor(p => p.Category, f => f.Lorem.Word())
        .RuleFor(p => p.Image, f => f.Internet.Url());

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        var product = ProductFaker.Generate();
        product.Description = product.Description.Length > 500
            ? product.Description[..500]
            : product.Description;
        return product;
    }

    /// <summary>
    /// Generates a valid product title.
    /// The generated title will:
    /// - Be a sentence string
    /// </summary>
    /// <returns>A valid product price.</returns>
    public static string GenerateValidTitle()
    {
        return new Faker().Lorem.Sentence();
    }

    /// <summary>
    /// Generates a valid product description.
    /// The generated description will:
    /// - Be a 2 paragraphs string
    /// - Max of 500 characters
    /// </summary>
    /// <returns>A valid product price.</returns>
    public static string GenerateValidDescription()
    {
        var description = new Faker().Lorem.Paragraphs(2);
        return description.Length > 500
            ? description[..500]
            : description;
    }

    /// <summary>
    /// Generates a valid product price.
    /// The generated price will:
    /// - Be a decimal between 0 and 99999
    /// </summary>
    /// <returns>A valid product price.</returns>
    public static decimal GenerateValidPrice()
    {
        return new Faker().Random.Decimal(0, 99999);
    }

    /// <summary>
    /// Generates a valid product category.
    /// The generated category will:
    /// - Be a single word string
    /// </summary>
    /// <returns>A valid product category.</returns>
    public static string GenerateValidCategory()
    {
        return new Faker().Lorem.Word();
    }

    /// <summary>
    /// Generates a valid product image.
    /// The generated image will:
    /// - Be a valid Url
    /// </summary>
    /// <returns>A valid product image.</returns>
    public static string GenerateValidImage()
    {
        return new Faker().Internet.Url();
    }
}