using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class EmployeeModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "The 'First Name' field is required.")]
        [StringLength(50, ErrorMessage = "The 'First Name' field cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The 'Last Name' field is required.")]
        [StringLength(50, ErrorMessage = "The 'Last Name' field cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The 'PESEL' field is required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "The 'PESEL' field must consist of 11 digits.")]
        public string PESEL { get; set; }

        [Required(ErrorMessage = "The 'Position' field is required.")]
        [StringLength(100, ErrorMessage = "The 'Position' field cannot be longer than 100 characters.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "The 'Department' field is required.")]
        [StringLength(50, ErrorMessage = "The 'Department' field cannot be longer than 50 characters.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "The 'Hire Date' field is required.")]
        [DataType(DataType.Date, ErrorMessage = "The 'Hire Date' field must be a date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "The 'Termination Date' field must be a date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [ValidateTermination(ErrorMessage = "Termination Date must be later than Hire Date.")]
        public DateTime? TerminationDate { get; set; }
    }

    public class ValidateTerminationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (EmployeeModel)validationContext.ObjectInstance;

            if (model.TerminationDate.HasValue && model.TerminationDate < model.HireDate)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
