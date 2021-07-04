using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Data.Entities
{
    public class MeetingItem
    {
        [Key]
        public int MeetingItemId { get; set; }
        public int MeetingId { get; set; }
        public int ItemId { get; set; }
        public string Comment { get; set; }
        public int ItemStatusId { get; set; }
        public int StaffId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

        [ForeignKey("MeetingId")]
        public virtual  Meeting Meeting { get; set; }
        [ForeignKey("ItemStatusId ")]
        public virtual ItemStatus ItemStatus { get; set; }
        public virtual List<StatusHistory> StatusHistory {get;set;}
    }
}
