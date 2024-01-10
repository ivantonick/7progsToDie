using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace iantonov.ContactService
{
    internal class SQLiteContactService : AbstractFileContactService
    {
        ContactsDbContext db;

        public SQLiteContactService(string dbPath) : base(dbPath)
        {
            db = new ContactsDbContext(dbPath);
        }

        public override void AddContact(Contact contact)
        {
            db.Attach(contact);
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public override void Dispose()
        {
            db.Dispose();
        }

        public override IEnumerable<Contact> GetContacts()
        {
            return db.Contacts;
        }

        public override void InitiateDatabase()
        {
            var db = new ContactsDbContext(dbPath);
            db.Database.EnsureCreated();
            db.Database.Migrate();
            db.Dispose();
        }
    }
}
