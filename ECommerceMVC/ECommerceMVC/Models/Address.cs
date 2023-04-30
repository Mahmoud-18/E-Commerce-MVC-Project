using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class Address
{
    public int Id { get; set; }
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    [DisplayName("Address Line")]
    public string Address1 { get; set; } = string.Empty;

    [ForeignKey("Country")]
    [DisplayName("Country")]
    public int CountryId { get; set; }

    [DisplayName("Customer")]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public DateTime CreatedOnUtc { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime? UpdatedOnUtc { get; set; }

    public DateTime? DeletedOnUtc { get; set; }

    //Navigation Properties

    public Customer? Customer { get; set; }
    public Country? Country { get; set; }
    public ICollection<OrderDetails>? Orders { get; set; } = new List<OrderDetails>();

}
