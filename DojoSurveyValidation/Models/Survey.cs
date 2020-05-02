using System.ComponentModel.DataAnnotations;

namespace DojoSurveyValidation.Models
{
  public class Survey
 
    {
        [Required(ErrorMessage="Please enter your name")]
        [MinLength(2,ErrorMessage="Please enter at least 2 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage="Please Select a Location")]
        public string Locations { get; set; }
        [Required(ErrorMessage="Please Select a Language")]
        public string Languages { get; set; }
        [MaxLength(20, ErrorMessage="Please keep Comment under 20 Characters")]
        public string Comments { get; set; }
        public Survey(string name, string lang, string place, string msg)
        {
            Name = name;
            Locations = lang;
            Languages = place;
            Comments = msg;
        }
    }
}