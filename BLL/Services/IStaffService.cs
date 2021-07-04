using MeetingsApp.Data;
using MeetingsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.BLL.Services
{
    public interface IStaffService : IGenericService<Staff>
    {

    }
    public class StaffService : GenericService<Staff>, IStaffService
    {
        public StaffService(MeetingsAppContext context) : base(context)
        {
        }

    }
}
