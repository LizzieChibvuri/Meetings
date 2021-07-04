using MeetingsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsApp.Data
{
    public class MeetingsAppContext:DbContext
    {
        public MeetingsAppContext(DbContextOptions<MeetingsAppContext> options) : base(options)
        {

        }
        public DbSet<ItemStatus> ItemStatuses { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingItem> MeetingItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StatusHistory> StatusHistory { get; set; }
    }
}
