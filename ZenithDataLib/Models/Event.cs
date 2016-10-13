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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Creates FK 
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual ApplicationUser User { get; set; }

        public Activity Activity { get; set; }
        public DateTime CreationDate { get; set; }
        public Boolean IsActive { get; set; }
   
    }
}
