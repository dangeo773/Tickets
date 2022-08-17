using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    public class Ticket_EnsureFutureDueDateOnCreationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext ValidationContext)
        {
            var ticket = ValidationContext.ObjectInstance as Ticket;
            if (!ticket.ValidateFutureDueDate())
                return new ValidationResult ("Due date has to be in the future.");

            return ValidationResult.Success;
        }
    }
}