using MeetingsApp.Data;
using MeetingsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.BLL.Services
{
    public interface IMeetingTypeService : IGenericService<MeetingType>
    {

    }
    public class MeetingTypeService : GenericService<MeetingType>, IMeetingTypeService
    {
        public MeetingTypeService(MeetingsAppContext context) : base(context)
        {
        }

    }
}
