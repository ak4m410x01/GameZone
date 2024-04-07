using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        public AllowedExtensionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        private readonly string _allowedExtensions;

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            // Try Cast Value to IFormFile.
            IFormFile? file = value as IFormFile;
            if (file == null)
                return new ValidationResult($"Invalid File");

            // Extract File Extension.
            string? extension = Path.GetExtension(file.FileName);
            if (extension == null)
                return new ValidationResult($"Only {_allowedExtensions} are allowed!");

            // Check if Extension is in allowed extensions or not.
            bool isAllowed = _allowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);
            if (!isAllowed)
                return new ValidationResult($"Only {_allowedExtensions} are allowed!");


            // If all validation is success return success.
            return ValidationResult.Success;
        }
    }
}
