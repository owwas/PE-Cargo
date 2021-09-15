using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PECargo.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
    }
}
