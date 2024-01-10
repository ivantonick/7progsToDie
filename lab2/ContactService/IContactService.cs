using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iantonov.ContactService
{
    internal interface IContactService : IDisposable
    {
        public IEnumerable<Contact> GetContacts();
        public void AddContact(Contact contact);
    }
}
