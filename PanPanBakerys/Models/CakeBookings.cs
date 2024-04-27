using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PanPanBakery.Models
{
    public class CakeBookings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 4)]
        [DisplayName("Name")]
        public string CakeName { get; set; }

        [DisplayName("Description")]
        public string CakeDescription { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public double price { get; set; }

        [DisplayName("Image")]
        public string ImageName { get; set; }



        public CakeBookings() { }
    }
}
