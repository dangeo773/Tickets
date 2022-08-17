using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    public class Ticket_EnsureDueDateAfterReportDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext ValidationContext)
        {
            var ticket = ValidationContext.ObjectInstance as Ticket;
            if (!ticket.ValidateDueDateAfterReportDate())
                return new ValidationResult ("Due Date must be later than Report Date");

            return ValidationResult.Success;
        }
    }
}