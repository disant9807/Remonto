using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo4ka7
{
    public class RepairsReferenceBook
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; }
        public string DescriptionIOfService { get; set; }
        public float price { get; set; }
        public string ServiceName { get; set; }
        public  ICollection<Repairs> Repairs { get; set; }
        public  ICollection<person> person { get; set; }
        public RepairsReferenceBook()
        {
            Repairs = new List<Repairs>();
            person = new List<person>();
        }
    }
}
