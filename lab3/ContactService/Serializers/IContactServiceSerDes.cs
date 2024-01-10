using iantonov.ContactService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iantonov.ContactService.Serializers
{
    internal interface IContactServiceSerDes
    {
        public IContactService Deserialize();
        public void Serialize(IContactService service);
    }
}
