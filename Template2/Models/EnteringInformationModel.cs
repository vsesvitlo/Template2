using System;
using System.ComponentModel.DataAnnotations;
namespace Template2.Models
{
	public class EnteringInformationModel
	{
        [Display(Name = "dateBirth")]
        public DateTime dateBirth { get; set; }
        [Display(Name = "timeWakeUp")]
		public TimeOnly timeWakeUp { get; set; }
	}
}

