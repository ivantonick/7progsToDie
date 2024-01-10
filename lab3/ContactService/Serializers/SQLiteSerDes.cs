using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace iantonov.ContactService.Serializers
{
    internal class SQLiteSerDes : AbstractFileSerDes, IDisposable
    {
        ContactsDbContext db;

        public SQLiteSerDes(string dbPath) : base(dbPath)
        {
            db = new ContactsDbContext(dbPath);
        }

        public override IContactService Deserialize()
        {
            IContactService service = new MemoryContactService();
            foreach (var contact in db.Contacts)
            {
                service.AddContact(contact);
            }
            return service;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public override void Initialize()
        {
            var db = new ContactsDbContext(DbPath);
            db.Database.EnsureCreated();
            db.Database.Migrate();
            db.Dispose();
        }

        public override void Serialize(IContactService service)
        {
            db.Contacts.ExecuteDelete();
            db.Contacts.AddRange(service.GetContacts().ToArray());
            db.SaveChanges();
        }
    }
}
