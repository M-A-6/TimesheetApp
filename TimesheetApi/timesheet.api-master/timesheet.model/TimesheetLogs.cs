using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace timesheet.model
{
    public class TimesheetLogs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
                
        [Required]
        public DateTime LogDate { get; set; }
                
        [Required]
        public int TaskId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public double Effort { get; set; }
    }
}
