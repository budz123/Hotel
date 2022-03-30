using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace ManageStaffDBApp.Model
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public int? ClientsId { get; set; }

        [ForeignKey("ClientsId")]
        public Client Client { get; set; }

        [Required]
        public int? RoomsId { get; set; }

        [ForeignKey("RoomsId")]
        public Room Room { get; set; }

        [Required]
        public string ReservationStatus { get; set; }
        [Required]
        public string typePayment { get; set; }

        [NotMapped]
        public Room ResRoom
        {
            get
            {
                return DataWorker.GetRoomById((int)RoomsId);
            }
        }
        [NotMapped]
        public Client ResClient
        {
            get
            {
                return DataWorker.GetclientById((int)ClientsId);
            }
        }

    }
}
