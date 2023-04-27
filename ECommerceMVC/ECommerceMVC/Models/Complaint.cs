using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }


        [ForeignKey("Customer")]
        public int Coustmer_ID { get; set; }
        public Customer? Customer { get; set; }
    }
}
