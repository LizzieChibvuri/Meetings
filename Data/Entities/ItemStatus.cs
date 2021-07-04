using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Data.Entities
{
    public class ItemStatus
    {
        [Key]
        public int ItemStatusId { get; set; }
        public string StatusName { get; set; }
        public virtual List<MeetingItem> MeetingItems { get; set; }

    }
}
