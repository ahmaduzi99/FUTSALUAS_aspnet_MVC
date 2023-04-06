using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Futsal.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string? username { get; set; }

        public string? email { get; set; }

        public string? phone { get; set; }

        public string? password { get; set; }


    }
}
