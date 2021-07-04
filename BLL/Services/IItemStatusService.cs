using MeetingsApp.Data;
using MeetingsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.BLL.Services
{
    public interface IItemStatusService : IGenericService<ItemStatus>
    {

    }
    public class ItemStatusService : GenericService<ItemStatus>, IItemStatusService
    {
        public ItemStatusService(MeetingsAppContext context) : base(context)
        {
        }

    }
}
