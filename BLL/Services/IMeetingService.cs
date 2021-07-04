
using MeetingsApp.Data;
using MeetingsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.BLL.Services
{
    public interface IMeetingService : IGenericService<Meeting>
    {
      public int AddMeeting(Meeting m);
     public Meeting GetMeeting(int id);
     public List<Meeting> GetAllMeetings();
     public  IEnumerable<MeetingItem> GetLastMinutesByMeetingType(int typeId);
    }
    public class MeetingService: GenericService<Meeting>,IMeetingService
    {
        public MeetingService(MeetingsAppContext context) : base(context)
        {
        }
       public  IEnumerable<MeetingItem> GetLastMinutesByMeetingType(int typeId)
        {
            List<MeetingItem> items = new List<MeetingItem>();
           
            //get  minutes from last meeting of supplied type
            var meeting = _context.Meetings.Where(m => m.MeetingTypeId == typeId).OrderByDescending(m => m.MeetingId).FirstOrDefault();
            
            if(meeting!=null)
            return meeting.MeetingItems.ToList();

            return items;
        }

        public int AddMeeting(Meeting m) 
        {
            _context.Meetings.Add(m);
            _context.SaveChanges();
            return m.MeetingId;
        }

        public Meeting GetMeeting(int id)
        {
            var meeting = _context.Meetings.Find(id);
            return meeting;
        }

        public List<Meeting> GetAllMeetings()
        {
            var meetings = _context.Meetings.ToList();
            return meetings;
        }
    }
}
