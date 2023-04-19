using System.ComponentModel.DataAnnotations;

namespace Futsal.Models.ViewModel
{
    public class LapanganForm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nama Lapangan Min 3 Huruf")]
        public string? NamaLapang { get; set; }

        public string? alamat { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "handphone Min 11 Huruf")]
        public string? number { get; set; }

        public string? photo { get; set; }
    }
}
