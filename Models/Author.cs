using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Herteg_Alina_Laboratorul2.Models
{
    public class Author
    {
        public int? ID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Book>? Books { get; set; }
    }
}
