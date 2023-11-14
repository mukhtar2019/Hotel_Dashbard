using System;
using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
	public class Rooms
	{
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(50)]
        public string Images { get; set; }
        [Required]
        public int RommNo { get; set; }
        [Required]
        public int IdHotels { get; set; }
    }
}

