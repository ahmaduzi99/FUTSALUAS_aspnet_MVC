using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities.Date;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Futsal.Models
{
    public class booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Nama min 3 Angka")]
		public string? nama { get; set; }
        public string? email { get; set; }
		[Required]
		[StringLength(13, MinimumLength = 11, ErrorMessage = "NO telp Min 11 Angka")]
		public string nphp { get; set; }
        public lapangan Lapangan { get; set; }
        public DateTime date { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public Status Status { get; set; }

    }
}
