using System.ComponentModel.DataAnnotations;

namespace Futsal.Models.ViewModel
{
    public class AdminForm
    {
        public int Id { get; set; }


        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Username Min 3 Huruf")]
        public string? username { get; set; }

        public string? email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "Telepon Min 11 Angka")]
        public string? phone { get; set; }

        public string? alamat { get; set; }

        public string? password { get; set; }

        public string? foto { get; set; }
    }
}
