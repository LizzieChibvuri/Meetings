using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Models
{
    public class MeetingDetailViewModel
    {
        public int MeetingId { get; set; }
        public string MeetingName { get; set; }
        public virtual  List<MeetingItemListViewModel> Items { get; set; }
    }

    public class MeetingItemListViewModel
    {
        public int MeetingItemId { get; set; }
        public string ItemDescription { get; set; }
        public string Comment { get; set; }
        public string StatusName { get; set; }
        public string ActionBy { get; set; }
    }
}
