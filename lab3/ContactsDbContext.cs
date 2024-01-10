using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace iantonov
{
    internal class ContactsDbContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set;}

        public string DbPath { get; }

        public ContactsDbContext(string dbPath)
        {
            DbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
