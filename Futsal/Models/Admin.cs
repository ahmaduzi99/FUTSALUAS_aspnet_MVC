using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Futsal.Models
{
	public class Admin
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Username Min 3 Huruf")]

        public string username { get; set; }

		public string? email { get; set; }

		public string? phone { get; set; }

		public string? alamat { get; set; }

        public string? password { get; set; }

        public string? foto { get; set; }


    }
}
