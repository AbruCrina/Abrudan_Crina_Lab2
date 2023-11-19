using System.ComponentModel.DataAnnotations;

namespace Abrudan_Crina_Lab2.Models
{
    public class Member
    {
        public int ID { get; set; }

       
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
"Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]

        [StringLength(30, MinimumLength = 3)]

        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]

        public string? LastName { get; set; }

        [StringLength(70)]
        public string? Adress { get; set; }
     
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Borrowing>? Borrowings { get; set; }
    }
}
