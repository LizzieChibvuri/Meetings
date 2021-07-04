using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Data.Entities
{
    public class Meeting
    {
        [Key]
        public int MeetingId { get; set; }
        public int MeetingTypeId { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime MeetingTime { get; set; }

        [ForeignKey("MeetingTypeId ")]
        public virtual MeetingType MeetingType { get; set; }
        public  virtual List<MeetingItem> MeetingItems { get; set; }

    }
}
