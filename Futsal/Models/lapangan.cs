using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Futsal.Models
{
	public class lapangan
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int Id { get; set; }

		public string? NamaLapang { get; set; }

		public string? alamat { get; set; }

		public string? number { get; set; }

		public string? photo { get; set; }

	}
}
