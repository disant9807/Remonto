using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo4ka7
{
   public class MachineReferenceBook
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Mark { get; set; }
        public string Name { get; set; }
        public DateTime DateAdd { get; set; }

        public  ICollection<Machine> Machine { get; set; }
        public  ICollection<person> person { get; set; }
        public MachineReferenceBook()

        {
            Machine = new List<Machine>();
            person = new List<person>();
        }
    }
}
