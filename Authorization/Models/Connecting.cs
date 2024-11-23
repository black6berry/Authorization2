using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Models
{
    internal class Connecting
    {
        public static CRUDdbEntities conn { get; } = new CRUDdbEntities();
    }
}
