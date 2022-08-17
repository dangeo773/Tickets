using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    public class Ticket_EnsureReportDatePresentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext ValidationContext)
        {
            var ticket = ValidationContext.ObjectInstance as Ticket;
            if (!ticket.ValidateReportDatePresence())
                return new ValidationResult ("Report Date must be present.");

            return ValidationResult.Success;
        }
    }
}