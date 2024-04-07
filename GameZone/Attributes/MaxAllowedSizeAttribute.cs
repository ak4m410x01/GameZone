using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
    public class MaxAllowedSizeAttribute : ValidationAttribute
    {
        public MaxAllowedSizeAttribute(int maxAllowedSizeInBytes)
        {
            _maxAllowedSizeInBytes = maxAllowedSizeInBytes;
        }

        private readonly int _maxAllowedSizeInBytes;

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            // Try Cast Value to IFormFile.
            IFormFile? file = value as IFormFile;
            if (file == null)
                return new ValidationResult($"Invalid File");

            // Extract File Extension.
            if (file.Length > _maxAllowedSizeInBytes)
                return new ValidationResult($"Maximum allowed size is {_maxAllowedSizeInBytes} bytes.");


            // If all validation is success return success.
            return ValidationResult.Success;
        }
    }
}
