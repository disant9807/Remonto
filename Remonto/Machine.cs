using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labo4ka7
{
    public class Machine
    {
        public int ID { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime YerOfIssue { get; set; }
        [ForeignKey("MachineReferenceBook")]
        public int MachineId { get; set; }
        public MachineReferenceBook MachineReferenceBook { get; set; }
        public  ICollection<person> person { get; set; }
        public  ICollection<Repairs> Repairs { get; set; }
        public Machine ()
        {
            person = new List<person>();
            Repairs = new List<Repairs>();
        }

    }
}
