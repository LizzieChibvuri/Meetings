
using MeetingsApp.Data;
using MeetingsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.BLL.Services
{
    public interface IMeetingItemService : IGenericService<MeetingItem>
    {
        public void UpdateStatus(int meetingItemId, int itemStatusID);
    }
    public class MeetingItemService : GenericService<MeetingItem>, IMeetingItemService
    {
        public MeetingItemService(MeetingsAppContext context) : base(context)
        {
        }

        public void UpdateStatus(int meetingItemId, int itemStatusID)
        {
            var mItem = _context.MeetingItems.Single(x => x.MeetingItemId ==meetingItemId);  

            mItem.ItemStatusId = itemStatusID;
        }
    }
}
