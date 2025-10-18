using System.ComponentModel.DataAnnotations;

namespace Board.Contracts.Attributes
{
    internal class BadAdvertTitlesValidationAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var badTitles = new[] { "Продаю мопед", "Продам мопед" };
            if (badTitles.Contains(value.ToString()))
            {
                return new ValidationResult("Нельзя продавать мопед");
            }

            return ValidationResult.Success;
        }
    }
}
