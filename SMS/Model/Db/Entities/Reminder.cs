using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model.Db.Entities
{
    public class Reminder
    {
        [Key]
        public Guid Id { get; set; }
        public string ReminderTitle { get; set; }
        public string ReminderText { get; set; }

    }
}
