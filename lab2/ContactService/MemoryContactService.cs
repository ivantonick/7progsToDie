using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iantonov.ContactService
{
    internal class MemoryContactService : IContactService
    {
        private List<Contact> contacts = new List<Contact>();
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void Dispose()
        {
            // noop
        }

        public IEnumerable<Contact> GetContacts()
        {
            return contacts.AsReadOnly();
        }
    }
}
