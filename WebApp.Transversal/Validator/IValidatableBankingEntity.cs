using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Transversales.Validator
{
    public interface IValidatableBankingEntity : IValidatableObject
    {
        new IEnumerable<BankingValidationResult> Validate(ValidationContext validationContext);
    }
}