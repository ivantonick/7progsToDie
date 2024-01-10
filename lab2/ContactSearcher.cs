using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iantonov.ContactService;

namespace iantonov
{
    internal class ContactSearcher
    {
        public enum SearchMode
        {
            [Description("Name")]
            NAME,

            [Description("Surname")]
            SURNAME,

            [Description("Name and Surname")]
            NAMEANDSURNAME,

            [Description("Phone")]
            PHONE,

            [Description("Email")]
            EMAIL
        }
        public SearchMode mode;

        public ContactSearcher(SearchMode mode)
        {
            this.mode = mode;
        }

        public bool ContactMatchesSearch(string query, Contact contact)
        {
            switch (this.mode)
            {
                case SearchMode.NAME: return contact.Name?.Contains(query) ?? false;
                case SearchMode.SURNAME: return contact.Name?.Contains(query) ?? false;
                case SearchMode.NAMEANDSURNAME: return (contact.Name ?? "" + contact.Surname ?? "").Contains(query);
                case SearchMode.PHONE: return contact.PhoneNumber?.Contains(query) ?? false;
                case SearchMode.EMAIL: return contact.Email?.Contains(query) ?? false;
                default: return false;
            }
        }

        public IEnumerable<Contact> SearchContacts(IContactService sercice, string query)
        {
            foreach (Contact contact in sercice.GetContacts())
            {
                if (ContactMatchesSearch(query, contact)) {
                    yield return contact;
                }
            }
        }
    }
}
