using System.ComponentModel.DataAnnotations;
namespace FirstResponsiveWebAppStonehocker.Models
{
    public class AgeThisYear
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter your birthday.")]

        public DateOnly? Birthday { get; set; }

        DateOnly Today = DateOnly.FromDateTime(DateTime.Today); //Gets todays date and makes it DateOnly

        public int? CalculateAge()
        {

            int age = Today.Year - Birthday.Value.Year;
            if (Birthday > Today.AddYears(-age)) //Checks to see if Birthday has happened yet this year
            {
                age--;
            }
            return age;
        }

    }
}
