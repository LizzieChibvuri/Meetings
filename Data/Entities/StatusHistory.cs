using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Data.Entities
{
    public class StatusHistory
    {
        [Key]
        public int StatusHistoryId { get; set; }
        public int ItemStatusId { get; set; }
        public DateTime StatusDate { get; set; }
      
        public int MeetingItemId { get; set; }

        [ForeignKey("MeetingItemId")]
        public virtual MeetingItem MeetingItem { get; set; }

    }
}
