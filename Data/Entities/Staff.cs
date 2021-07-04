using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Data.Entities
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<MeetingItem> MeetingItems { get; set; }
    }
}
