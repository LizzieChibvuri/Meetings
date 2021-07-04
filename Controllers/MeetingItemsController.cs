using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingsApp.Data;
using MeetingsApp.Data.Entities;
using MeetingsApp.Models;
using MeetingsApp.BLL.Services;

namespace MeetingsApp.Controllers
{
    public class MeetingItemsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeetingItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: MeetingItems
        public  IActionResult Index()
        {
            var meetingsAppContext = _unitOfWork.MeetingItems.GetAll();
            return View( meetingsAppContext.ToList());
        }

        // GET: MeetingItems/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingItem = _unitOfWork.MeetingItems.GetById(id.GetValueOrDefault());
            if (meetingItem == null)
            {
                return NotFound();
            }

            return View(meetingItem);
        }

        // GET: MeetingItems/Create
        public IActionResult Create(int id )
        {
            MeetingItemViewModel miv = new MeetingItemViewModel();
            miv.MeetingId = id;

            ViewData["ItemStatusId"] = new SelectList(_unitOfWork.ItemStatuses.GetAll(), "ItemStatusId", "StatusName");
            ViewData["StaffId"] = new SelectList(_unitOfWork.Staff.GetAll(), "StaffId", "FirstName");
            return View(miv);
        }

        // POST: MeetingItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MeetingItemId,MeetingId,ItemId,ItemDescription,DueDate,Comment,ItemStatusId,StaffId")] MeetingItemViewModel meetingItem)
        {
            if (ModelState.IsValid)
            {
                Item i = new Item();
                i.ItemDescription = meetingItem.ItemDescription;
                i.DueDate = meetingItem.DueDate;

                int itemId= _unitOfWork.Items.AddItem(i);

                MeetingItem mi = new MeetingItem();
                mi.MeetingId = meetingItem.MeetingId;
                mi.ItemId = itemId;
                mi.Comment = meetingItem.Comment;
                mi.ItemStatusId = meetingItem.ItemStatusId;
                mi.StaffId = meetingItem.StaffId;

                _unitOfWork.MeetingItems.Add(mi);
                _unitOfWork.Complete();

                return RedirectToAction(nameof(Details), "Meetings", new { id = meetingItem.MeetingId });
               
            }
            ViewData["ItemStatusId"] = new SelectList(_unitOfWork.ItemStatuses.GetAll(), "ItemStatusId", "StatusName", meetingItem.ItemStatusId);
            ViewData["StaffId"] = new SelectList(_unitOfWork.Staff.GetAll(), "StaffId", "FirstName", meetingItem.StaffId);
            return View(meetingItem);
        }

        // GET: MeetingItems/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingItem =  _unitOfWork.MeetingItems.GetById(id.GetValueOrDefault());
            if (meetingItem == null)
            {
                return NotFound();
            }

            MeetingItemViewModel miv = new MeetingItemViewModel();
            miv.MeetingItemId = meetingItem.MeetingItemId;
            miv.MeetingId = meetingItem.MeetingId;
            miv.ItemId = meetingItem.ItemId;
            miv.ItemDescription = meetingItem.Item.ItemDescription;
            miv.DueDate = meetingItem.Item.DueDate;
            miv.Comment = meetingItem.Comment;
            miv.ItemStatusId = meetingItem.ItemStatusId;
            miv.StaffId = meetingItem.StaffId;

            ViewData["ItemStatusId"] = new SelectList(_unitOfWork.ItemStatuses.GetAll(), "ItemStatusId", "StatusName",meetingItem.ItemStatusId);
            ViewData["StaffId"] = new SelectList(_unitOfWork.Staff.GetAll(), "StaffId", "FirstName",meetingItem.StaffId);
            return View(miv);
        }

        // POST: MeetingItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MeetingItemId,MeetingId,ItemId,ItemDescription,DueDate,Comment,ItemStatusId,StaffId")] MeetingItemViewModel meetingItem)
        {
            if (id != meetingItem.MeetingItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  
                    _unitOfWork.MeetingItems.UpdateStatus( meetingItem.MeetingItemId,meetingItem.ItemStatusId);
                    _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingItemExists(meetingItem.MeetingItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Details), "Meetings", new { id = meetingItem.MeetingId });
            }
            ViewData["ItemStatusId"] = new SelectList(_unitOfWork.ItemStatuses.GetAll(), "ItemStatusId", "StatusName", meetingItem.ItemStatusId);
            ViewData["StaffId"] = new SelectList(_unitOfWork.Staff.GetAll(), "StaffId", "FirstName", meetingItem.StaffId);
            return View(meetingItem);
        }



        private bool MeetingItemExists(int id)
        {
            return _unitOfWork.MeetingItems.GetAll().Any(e => e.MeetingItemId == id);
        }
    }
}
