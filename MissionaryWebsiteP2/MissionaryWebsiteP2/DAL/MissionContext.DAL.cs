using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MissionaryWebsiteP2.Models;
using System.Data.Entity;

namespace MissionaryWebsiteP2.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext() : base("MissionContext")
        {

        }

        public DbSet<Missions> Brothers { get; set; }
        public DbSet<MissionQuestions> MissionQuestion { get; set; }
        public DbSet<users> user { get; set; }

    }
}