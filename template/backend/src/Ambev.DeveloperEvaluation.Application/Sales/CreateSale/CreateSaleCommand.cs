﻿using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale, 
/// including userId, products, and branch. 
/// It implements <see cref="IRequest"/> to initiate the request 
/// that returns a <see cref="CreateSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    /// <summary>
    /// Gets or sets the customer's unique identifier.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets or sets a list of products, containing ids and quantities
    /// </summary>
    public IEnumerable<SaleProduct> Products { get; set; }

    /// <summary>
    /// Gets or sets branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;
    
    /// <summary>
    /// Validates the creation command through <see cref="CreateSaleCommandValidator"/>
    /// </summary>
    /// <returns><see cref="ValidationResultDetail"/></returns>
    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}