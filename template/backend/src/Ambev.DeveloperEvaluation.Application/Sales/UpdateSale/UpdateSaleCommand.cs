using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for updating an existing sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a sale
/// It implements <see cref="IRequest"/> to initiate the request 
/// that returns a <see cref="UpdateSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    /// <summary>
    /// The sale's unique identifier.
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Gets or sets a list of products, containing ids and quantities
    /// </summary>
    public IEnumerable<SaleProduct> Products { get; set; }

    /// <summary>
    /// Gets or sets branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;
    
        
    /// <summary>
    /// Validates the update command through <see cref="UpdateSaleCommandValidator"/>
    /// </summary>
    /// <returns><see cref="ValidationResultDetail"/></returns>
    public ValidationResultDetail Validate()
    {
        var validator = new UpdateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}