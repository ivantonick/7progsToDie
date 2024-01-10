using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace iantonov.ContactService.Serializers
{
    [Serializable]
    [XmlRoot("Contacts")]
    public class Contacts
    {
        [XmlArray("ContactList"), XmlArrayItem(typeof(Contact), ElementName = "Contact")]
        public List<Contact>? ContactList { get; set; }
    }

    internal class XMLSerDes : AbstractStreamSerDes
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Contacts));
        public XMLSerDes(string dbPath) : base(dbPath) { }

        public override List<Contact> Read(Stream stream)
        {
            return ((Contacts)serializer.Deserialize(stream)!).ContactList!;
        }

        public override void Write(IEnumerable<Contact> contacts, Stream stream)
        {
            Contacts contactsObject = new Contacts
            {
                ContactList = contacts.ToList()
            };
            serializer.Serialize(stream, contactsObject);
        }

        public override void WriteInitial(Stream stream)
        {
            Contacts contactsObject = new Contacts
            {
                ContactList = Enumerable.Empty<Contact>().ToList()
            };
            serializer.Serialize(stream, contactsObject);
        }
    }
}
