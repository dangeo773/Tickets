using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    public class Ticket_EnsureDueDatePresentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext ValidationContext)
        {
            var ticket = ValidationContext.ObjectInstance as Ticket;
            if (!ticket.ValidateDueDatePresence())
                return new ValidationResult ("Due date is required.");

            return ValidationResult.Success;
        }
    }
}