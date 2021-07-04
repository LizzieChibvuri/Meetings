using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Data.Entities
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public DateTime DueDate { get; set; }
        public virtual  List<MeetingItem> MeetingItems { get; set; }
    }
}
