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

        public DateTime CreatedOnUtc { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOnUtc { get; set; }


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
