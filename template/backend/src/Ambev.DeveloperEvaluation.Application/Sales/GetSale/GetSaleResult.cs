﻿using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The sale's number.
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// The sale's unique identifier.
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// The customer's unique identifier.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// The sale's date of creation.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// A list of products, containing ids and quantities
    /// </summary>
    public IEnumerable<SaleProduct> Products { get; set; }
    
    /// <summary>
    /// Total sale amount
    /// </summary>
    public decimal TotalSaleAmount { get; set; }
    
    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// Discounts for sale, if match business rule
    /// </summary>
    public SaleDiscount? Discount { get; set; }
    
    /// <summary>
    /// Sale status, can be created or canceled
    /// </summary>
    public SaleStatus Status { get; set; }

    /// <summary>
    /// Calculates the final price, products * quantities - discount (if available).
    /// </summary>
    public void CalculateFinalPrice()
    {
        TotalSaleAmount = Discount is null
            ? Products.Sum(p => p.TotalAmount)
            : Products.Sum(p => p.TotalAmount) - Discount.Amount;
    }
}