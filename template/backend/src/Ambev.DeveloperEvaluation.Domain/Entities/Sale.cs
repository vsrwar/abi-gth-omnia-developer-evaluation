using MongoDB.Bson.Serialization.Attributes;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Services.Discount;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Representes a sale on the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale
{
    [BsonId]
    public ObjectId _id { get; set; }
    /// <summary>
    /// Gets the sale number.
    /// </summary>
    public int Number { get; private set; }
    
    /// <summary>
    /// Gets the date when the sale was made.
    /// </summary>
    public DateTime Date { get; private set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Gets the customer's unique identifier of the review.
    /// Must not be null or empty
    /// </summary>
    public Guid UserId { get; private set; }
    
    /// <summary>
    /// Total sale amount, discount not applied.
    /// </summary>
    public decimal TotalAmount { get; private set; }
    
    /// <summary>
    /// Branch where the sale was made.
    /// </summary>
    public string Branch { get; private set; }
    
    /// <summary>
    /// A list with all Products on Sale
    /// </summary>
    public IEnumerable<SaleProduct> Products { get; private set; }
    
    /// <summary>
    /// Discount applied to sale.
    /// </summary>
    /// <remarks>
    /// <para>Purchases above 4 identical items have a 10% discount</para>
    /// <para>Purchases between 10 and 20 identical items have a 20% discount</para>
    /// <para>Purchases below 4 items cannot have a discount</para>
    /// </remarks>
    public SaleDiscount? Discount { get; private set; }

    /// <summary>
    /// Sale status on the system.
    /// </summary>
    public SaleStatus Status { get; private set; } = SaleStatus.Created;
    
    public Sale CalculateDiscount()
    {
        Discount = DiscountHandler.Calculate(Products);
        return this;
    }

    /// <summary>
    /// Calculates the total amount, discounts not applied.
    /// </summary>
    /// <remarks>Sum of Product.Quantity * Product.Price</remarks>
    public Sale CalculateTotalAmount()
    {
        TotalAmount = Products.Sum(x => x.Price * x.Quantity);
        return this;
    }

    /// <summary>
    /// Updates current product prices
    /// </summary>
    /// <param name="products">Products with updated prices</param>
    /// <returns>This instance of Sale</returns>
    public Sale UpdateProductsPrices(IEnumerable<Product> products)
    {
        foreach (var product in Products)
        {
            product.Price = products.FirstOrDefault(p => p.Id == product.ProductId)?.Price ?? product.Price;
        }

        return this;
    }

    /// <summary>
    /// Cancels a sale
    /// </summary>
    public void Cancel()
    {
        Status = SaleStatus.Cancelled;
    }

    /// <summary>
    /// Calculates Discounts and Total amount with updated prices from parameter
    /// </summary>
    public void Calculate(IEnumerable<Product> products)
    {
        UpdateProductsPrices(products);
        CalculateDiscount();
        CalculateTotalAmount();
    }
}