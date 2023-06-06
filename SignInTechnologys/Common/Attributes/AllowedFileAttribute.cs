using System.ComponentModel.DataAnnotations;

namespace SignInTechnologys.Common.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class AllowedFilesAttribute : ValidationAttribute
{
    private readonly string[] _extensions;
    public AllowedFilesAttribute(string[] extensions)
    {
        this._extensions = extensions;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file is not null)
        {
            var extension = Path.GetExtension(file.FileName);
            if (_extensions.Contains(extension.ToLower()))
                return ValidationResult.Success;
            
            else return new ValidationResult("This file extension is not supperted!");
        }
        else return ValidationResult.Success;
    }
}
