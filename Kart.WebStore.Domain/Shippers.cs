using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kart.WebStore.Domain
{
    public class Shippers
    {
        public Guid Id { get; set; }
        public string Mode { get; set; } = null!;
        public string ShippingType { get; set; } = null!;

    }
}
