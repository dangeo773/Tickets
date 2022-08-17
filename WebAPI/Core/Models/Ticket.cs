using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.ValidationAttributes;

namespace Core.Models
{
    public class Ticket
    {
        public int? TicketId{get; set;}
        [Required]
        public int? ProjectId{get; set;}
        [Required]
        [StringLength(100)]
        public string? Title { get; set;}
        public string? Description {get; set;}
        [StringLength(50)]
        public string? Owner {get; set;}

        [Ticket_EnsureReportDatePresent]
        public DateTime? ReportDate {get; set; }

    
        [Ticket_EnsureFutureDueDateOnCreation]
        [Ticket_EnsureDueDateAfterReportDate]
        [Ticket_EnsureDueDatePresent]

        public DateTime? DueDate {get; set;}

        public Project? Project {get; set;}

        public bool ValidateFutureDueDate()
        {
            if (TicketId.HasValue) return true;
            if (!DueDate.HasValue) return true;

            return (DueDate.Value > DateTime.Now);
        }

        public bool ValidateReportDatePresence()

        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return ReportDate.HasValue;
        }

        public bool ValidateDueDatePresence()

        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return DueDate.HasValue;
        }
        
        public bool ValidateDueDateAfterReportDate()
        {
            if (!DueDate.HasValue || !ReportDate.HasValue) return true;

            return DueDate.Value.Date >= ReportDate.Value.Date;
        }
    }
}