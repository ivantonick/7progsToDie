using iantonov.ContactService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iantonov.ContactService.Serializers
{
    abstract class AbstractFileSerDes : IContactServiceSerDes
    {
        protected string DbPath;
        protected AbstractFileSerDes(string dbPath)
        {
            this.DbPath = dbPath;
            if (!File.Exists(this.DbPath))
            {
                Initialize();
            }
            Debug.Assert(File.Exists(this.DbPath));
        }

        public abstract void Initialize();
        public abstract IContactService Deserialize();
        public abstract void Serialize(IContactService service);
    }
}
