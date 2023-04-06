using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Futsal.Models
{
    public class booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string? nama { get; set; }

        public string? email { get; set; }

        public string nphp { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly start { get; set; }

        public TimeOnly end { get; set; }


    }
}
