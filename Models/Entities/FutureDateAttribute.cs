using System;
using System.ComponentModel.DataAnnotations;

namespace TaskMasterAPI.Models.Entities;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date && date > DateTime.Now)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult(ErrorMessage ?? "A data deve ser futura");
    }
}
