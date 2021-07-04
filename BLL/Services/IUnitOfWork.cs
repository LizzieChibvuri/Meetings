using MeetingsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.BLL.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IMeetingService Meetings { get; }
        IMeetingItemService MeetingItems { get; }
        IMeetingTypeService MeetingTypes { get; }
        IStaffService Staff { get; }
        IItemStatusService ItemStatuses { get; }
        IItemService Items { get; }
        int Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeetingsAppContext _context;
        public UnitOfWork(MeetingsAppContext context)
        {
            _context = context;
            Meetings = new MeetingService(_context);
            MeetingItems = new MeetingItemService(_context);
            Staff = new StaffService(_context);
            MeetingTypes = new MeetingTypeService(_context);
            ItemStatuses = new ItemStatusService(_context);
            Items = new ItemService(_context);
        }
        public IMeetingService Meetings { get; private set; }
        public IItemService Items { get; private set; }
        public IMeetingItemService MeetingItems { get; private set; }
        public IStaffService Staff { get; private set; }
        public IMeetingTypeService MeetingTypes { get; private set; }
        public IItemStatusService ItemStatuses { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
