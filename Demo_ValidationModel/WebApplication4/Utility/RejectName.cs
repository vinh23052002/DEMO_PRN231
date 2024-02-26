using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Utility
{
    public class RejectName : ValidationAttribute
    {
        public string _rejectName { get; set; }
        public RejectName(string rejectName)
        {
            _rejectName = rejectName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var name = value as string;

            if (name != null && name.ToLower().Trim().Equals(_rejectName.ToLower().Trim()))
            {
                return new ValidationResult($"This name is not allowed!!");
            }

            return ValidationResult.Success;
        }

    }
}
