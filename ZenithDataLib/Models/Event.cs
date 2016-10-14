using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenithSociety.Models;

namespace ZenithDataLib.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        ////Creates FK 
        [Display(Name = "Created By")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Creation Date")]
        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Activity")]
        public Boolean IsActive { get; set; }

        [Display(Name = "Activity Decription")]
        public int  ActivityId { get; set; }
        public Activity Activity { get; set; }

    }
}
