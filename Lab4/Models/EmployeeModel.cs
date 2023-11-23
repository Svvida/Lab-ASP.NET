using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class EmployeeModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public DateTime Created {  get; set; } = DateTime.Now;

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First Name cannot be longer than 100 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last Name cannot be longer than 100 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "PESEL is required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL must consist of 11 digits.")]
        [Display(Name = "PESEL")]
        public string PESEL { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        [Display(Name = "Position")]
        [StringLength(100, ErrorMessage = "Position cannot be longer than 100 characters.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [Display(Name = "Department")]
        [StringLength(100, ErrorMessage = "Department cannot be longer than 100 characters.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Hire Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Enter a valid Hire Date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "The 'Termination Date' must be a date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Termination Date")]
        [ValidateTermination(ErrorMessage = "Termination Date must be later than Hire Date.")]
        public DateTime? TerminationDate { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        [Display(Name ="Priority")]
        public Priority Priority { get; set; }
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
