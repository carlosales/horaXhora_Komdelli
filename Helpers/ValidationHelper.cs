using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using hora_Komdelli.Models;

namespace hora_Komdelli.Helpers;

public static class ValidationHelper
{
    public static (bool IsValid, List<string> Errors) ValidateModel<T>(T model) where T : notnull
    {
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

        var errors = results
            .Where(r => r.ErrorMessage is not null)
            .Select(r => r.ErrorMessage!)
            .ToList();

        return (isValid, errors);
    }
}
