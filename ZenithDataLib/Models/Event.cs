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
        [Display(Name = "Start Date & Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM'/'dd'/'yyyy hh:mm tt}")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date & Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM'/'dd'/'yyyy hh:mm tt}")]
        public DateTime EndDate { get; set; }

        ////Creates FK 
        [Display(Name = "Created By")]
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Creation Date")]
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy hh:mm tt}")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active")]
        public Boolean IsActive { get; set; }

        [Display(Name = "Activity Decription")]
        public int  ActivityId { get; set; }
        public Activity Activity { get; set; }

        //Checks if EndDate is later than StartDate and if Event happens in same day
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return
                  new ValidationResult(errorMessage: "End Date & Time must be greater than Start Date & Time",
                                       memberNames: new[] { "EndDate" });
            }

            if (EndDate.Date != StartDate.Date)
            {
                yield return
                  new ValidationResult(errorMessage: "Event Start Date and End Date must occur on the same day",
                                       memberNames: new[] { "EndDate" });
            }
        }
    }
}
