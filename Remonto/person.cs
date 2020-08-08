using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo4ka7
{
    public class person
    {
        public int ID { get; set; }
        public DateTime DateAdd { get; set; }
        public string FIO { get; set; }
        public string Status { get; set; }
        public int phoneSmart { get; set; }
        public int phoneStac { get; set; }
        public DateTime DateOfRegistrarion { get; set; }
        public string CompanyName { get; set; }
        public string AccesCode { get; set; }
        public DateTime DateLastAutorization { get; set; }
        public  ICollection<Machine> Machine { get; set; }
        public  ICollection<MachineReferenceBook> MachineReferenceBooks { get; set; }
        public  ICollection<Repairs> Repairs { get; set; }
        public  ICollection<RepairsReferenceBook> RepairsReferenceBook { get; set; }
        public person()
        {
            Machine = new List<Machine>();
            MachineReferenceBooks = new List<MachineReferenceBook>();
            Repairs = new List<Repairs>();
            RepairsReferenceBook = new List<RepairsReferenceBook>();
        }
        

    }
}
