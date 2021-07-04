using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingsApp.Data;
using MeetingsApp.Data.Entities;
using MeetingsApp.BLL.Services;
using MeetingsApp.Models;

namespace MeetingsApp.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeetingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Meetings
        public IActionResult Index()
        {
            var meetingsAppContext = _unitOfWork.Meetings.GetAll();
            return View(meetingsAppContext.ToList());
        }

       

        // GET: Meetings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting =  _unitOfWork.Meetings.GetMeeting(id.GetValueOrDefault());
              
            if (meeting == null)
            {
                return NotFound();
            }

            MeetingDetailViewModel md = new MeetingDetailViewModel();
            md.MeetingId = meeting.MeetingId;
            md.MeetingName = meeting.MeetingType.TypeName + " Minutes(" + meeting.MeetingType.ShortName + meeting.MeetingId + ")-" + meeting.MeetingDate.ToString("dd MMMM yyyy");
            md.Items = meeting.MeetingItems.Select(o => new MeetingItemListViewModel
            {
                MeetingItemId=o.MeetingItemId,
                ItemDescription=o.Item.ItemDescription,
                Comment=o.Comment,
                StatusName=o.ItemStatus.StatusName,
                ActionBy=o.Staff.FirstName.Substring(0,1)+o.Staff.LastName.Substring(0,1)

            }).ToList();

            return View(md);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            ViewData["MeetingTypeId"] = new SelectList(_unitOfWork.MeetingTypes.GetAll(), "MeetingTypeId", "TypeName");
            return View();
        }

        [HttpGet]
        public JsonResult GetLastMinutesByTypeId(int id)
        {
            List<MeetingItem> itemList = _unitOfWork.Meetings.GetLastMinutesByMeetingType(id).ToList();

            var items = itemList.Select(i => new MeetingItemSelectViewModel
            {
                MeetingItemId = i.MeetingItemId,
                ItemDescription = i.Item.ItemDescription
            }).ToList();

            items.Insert(0, new MeetingItemSelectViewModel { MeetingItemId = 0, ItemDescription = "Select" });
           
            return Json(new SelectList(items, "MeetingItemId", "ItemDescription")); // return same page with different model contents
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingId,MeetingTypeId,MeetingDate,MeetingTime,oldItemIDs")] MeetingViewModel meeting)
        {

            if (ModelState.IsValid)
            {
                Meeting m = new Meeting();
                m.MeetingTypeId = meeting.MeetingTypeId;
                m.MeetingDate = meeting.MeetingDate.Date;
                m.MeetingTime = meeting.MeetingTime;
               

                int meetingId = _unitOfWork.Meetings.AddMeeting(m);

                if (meeting.oldItemIDs!=null)
                {
                    List<MeetingItem> mi = new List<MeetingItem>();
                    for (int i=0; i < meeting.oldItemIDs.Length; i++)
                    {
                       //get meetingitem for current values
                       var mItem= _unitOfWork.MeetingItems.GetById(meeting.oldItemIDs[i]);

                        MeetingItem item = new MeetingItem();
                        item.MeetingId = meetingId;
                        item.StaffId = mItem.StaffId;
                        item.Comment = mItem.Comment;
                        item.ItemId =mItem.ItemId;
                        item.ItemStatusId = mItem.ItemStatusId;

                        mi.Add(item);

                    }

                    if (mi != null)
                        _unitOfWork.MeetingItems.AddRange(mi);

                }
                
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Details),  new { id = meetingId});
            }

            ViewData["MeetingTypeId"] = new SelectList(_unitOfWork.MeetingTypes.GetAll(), "MeetingTypeId", "TypeName", meeting.MeetingTypeId);
            return View(meeting);
        }


    }
}
