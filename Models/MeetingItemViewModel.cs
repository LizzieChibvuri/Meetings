using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Models
{
    public class MeetingItemViewModel
    {
      
        public int MeetingItemId { get; set; }
        public int MeetingId { get; set; }
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Item description is required")]
        public string ItemDescription { get; set; }
        [Required(ErrorMessage = "Due date is required")]
        public DateTime DueDate { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Item Status")]
        public int ItemStatusId { get; set; }
        [Display(Name = "Stuff Name")]
        public int StaffId { get; set; }
   
    }
}
