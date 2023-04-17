using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Futsal.Models
{
    public class Status

    {
        [Key]
        public int Id { get; set; }
        public string Stat { get; set; }
    }
}