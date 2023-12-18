using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class OderTbl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public int ItemQty { get; set; }
        public DateTime OrderDelivery { get; set; }
        public string OrderAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
