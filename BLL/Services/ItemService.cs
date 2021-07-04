using MeetingsApp.Data;
using MeetingsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.BLL.Services
{

    public interface IItemService : IGenericService<Item>
    {
        public int AddItem(Item i);
    }
    public class ItemService : GenericService<Item>, IItemService
    {
        public ItemService(MeetingsAppContext context) : base(context)
        {
        }
        public int AddItem(Item i)
        {
            _context.Items.Add(i);
            _context.SaveChanges();
            return i.ItemId;
        }

    }
}
