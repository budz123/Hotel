using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ManageStaffDBApp.Model
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Capfcity { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Price { get; set; }

    }
}
