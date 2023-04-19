using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Futsal.Models
{
	public class lapangan
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nama Lapangan Min 3 Huruf")]
        public string? NamaLapang { get; set; }

		public string? alamat { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 11, ErrorMessage = "NO telp Min 11 Angka")]
        public string? number { get; set; }

		public string? photo { get; set; }

	}
}
