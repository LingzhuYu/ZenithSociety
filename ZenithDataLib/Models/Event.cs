using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ZenithSociety.Models;

namespace ZenithDataLib.Models
{
    public class Event: IValidatableObject
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        ////Creates FK 
        [Display(Name = "Created By")]
        [ScaffoldColumn(false)]
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

        //Checks if EndDate is later than StartDate
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return
                  new ValidationResult(errorMessage: "EndDate must be greater than StartDate",
                                       memberNames: new[] { "EndDate" });
            }
        }
    }
}
