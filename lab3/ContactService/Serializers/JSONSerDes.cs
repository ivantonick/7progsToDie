using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace iantonov.ContactService.Serializers
{
    internal class JSONSerDes : AbstractStreamSerDes
    {
        public JSONSerDes(string dbPath) : base(dbPath) { }

        public override List<Contact> Read(Stream stream)
        {
            return (List<Contact>) JsonSerializer.Deserialize(stream, typeof(List<Contact>))!;
        }

        public override void Write(IEnumerable<Contact> contacts, Stream stream)
        {
            JsonSerializer.Serialize(stream, contacts);
        }

        public override void WriteInitial(Stream stream)
        {
            stream.Write(Encoding.UTF8.GetBytes("{}"));
        }
    }
}
