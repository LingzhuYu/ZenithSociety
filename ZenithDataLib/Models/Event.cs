using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
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
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Creation Date")]
        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active")]
        public Boolean IsActive { get; set; }

        [Display(Name = "Activity Decription")]
        public int  ActivityId { get; set; }
        public Activity Activity { get; set; }

    }
}
