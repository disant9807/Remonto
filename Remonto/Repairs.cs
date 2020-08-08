using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labo4ka7
{
   public class Repairs
    {
        public int ID { get; set; }
        public int price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AddDate { get; set; }
        public bool oplata { get; set; }
        public string AdditionalInformation { get; set; }
        public float paid { get; set; }
        public string CharacterOfFailure { get; set; }
        [ForeignKey("Machine")]
        public int? IDMachine { get; set; }
        public Machine Machine { get; set; }
        public  ICollection<person> person { get; set; }
        public  ICollection<RepairsReferenceBook> RepairsReferenceBook { get; set; }

        public Repairs ()
        {
            person = new List<person>();
            RepairsReferenceBook = new List<RepairsReferenceBook>();
        }

    }
}
