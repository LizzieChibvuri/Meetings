using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Data.Entities
{
    public class MeetingType
    {
        [Key]
        public int MeetingTypeId { get; set; }
        public string TypeName { get; set; }
        public string ShortName { get; set; }
        public virtual List<Meeting> Meetings{get;set;}
    }
}
