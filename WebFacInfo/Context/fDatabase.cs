using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebFacInfo.Models;

namespace WebFacInfo.Context
{
    public class fDatabase : DbContext
    {
        public fDatabase() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\KOSTA\Desktop\MyDatabase.mdf"";Integrated Security=True;Connect Timeout=30")
        { }

        public DbSet<fInfo> facilities { get; set; }
    }
}