using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcesss.Data
{
    public class HotelRoom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public double RegularRate { get; set; }
        public string Details { get; set; }
        public string SqFt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<HotelRoomImage> HotelRoomImages { get; set; }
    }
}
