using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Display(Name = "Activity Description")]
        public string ActivityDescription { get; set; }

        [Display(Name = "Creation Date")]
        [ScaffoldColumn(false)]
        public DateTime CreationDate { get;  set;}

        public List<Event> Events { get; set; }
    }
}
