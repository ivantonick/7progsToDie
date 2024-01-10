using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace iantonov.ContactService.Serializers
{
    abstract class AbstractStreamSerDes: AbstractFileSerDes
    {
        public AbstractStreamSerDes(string dbPath) : base(dbPath) { }

        public override IContactService Deserialize()
        {
            using FileStream reader = File.OpenRead(this.DbPath);
            List<Contact> contacts = Read(reader);
            IContactService service = new MemoryContactService();
            foreach (Contact contact in contacts!)
            {
                service.AddContact(contact);
            }
            return service;
        }
        public abstract List<Contact> Read(Stream stream);
        public abstract void Write(IEnumerable<Contact> contacts, Stream stream);

        public abstract void WriteInitial(Stream stream);

        public override void Initialize()
        {
            using Stream stream = File.Create(DbPath);
            WriteInitial(stream);
        }

        public override void Serialize(IContactService service)
        {
            using FileStream writer = File.Create(this.DbPath);
            Write(service.GetContacts(), writer);
        }
    }
}
