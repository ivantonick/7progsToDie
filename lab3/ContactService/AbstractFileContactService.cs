using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iantonov.ContactService
{
    abstract internal class AbstractFileContactService : IContactService
    {
        protected string dbPath;

        protected AbstractFileContactService(string dbPath)
        {
            this.dbPath = dbPath;
            if (!File.Exists(this.dbPath))
            {
                InitiateDatabase();
            }
            Debug.Assert(File.Exists(this.dbPath));
        }

        public abstract void InitiateDatabase();

        public abstract void AddContact(Contact contact);
        public abstract IEnumerable<Contact> GetContacts();
        public abstract void Dispose();
    }
}
