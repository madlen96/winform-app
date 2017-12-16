using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("CompanyName")]
        public Customer Customer { get; set; }
        public string CompanyName { get; set; }
    }
}
