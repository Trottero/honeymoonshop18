using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public String Naam { get; set; }
        public String Beoordeling { get; set; }

        [Display(Name = "Klant Review")]
        public String klantReview { get; set; }

        //navigation Property
        public int JurkID { get; set; }
        public virtual Jurk Jurk { get; set; }



        
    }
}
