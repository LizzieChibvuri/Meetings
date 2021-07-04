using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Models
{
    public class MeetingViewModel
    {
        public int MeetingId { get; set; }
        [Required(ErrorMessage ="Meeting Type is required")]
        [Display(Name ="Meeting Type")]
        public int MeetingTypeId { get; set; }
        [Required(ErrorMessage = "Meeting date is required")]
        public DateTime MeetingDate { get; set; }
        [Required(ErrorMessage = "Meeting time is required")]
        public DateTime MeetingTime { get; set; }
        public int [] oldItemIDs { get; set; }
    }
}
