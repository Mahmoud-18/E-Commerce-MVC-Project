﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public DateTime DataOfBirth { get; set; }
    public Gender Gender { get; set; }

    [ForeignKey("CountryId")]
    public int CountryId { get; set; }
    public int MobileNumber { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; } 
    public DateTime CreatedOnUtc { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeleteDate { get; set; }
    public bool IsActive { get; set; } = true;

    //[ForeignKey("Address")]
    public int? ShippingAddressId { get; set; }
    public bool IsAdmin { get; set; } = false;
    public string? AdminComment { get; set; }
    public bool HasShoppingBagItems { get; set; } = false;
    public bool? RequireReLogin { get; set; }
    public int? FailedLoginAttempts { get; set; }
    public DateTime? CannotLoginUntilDateUtc { get; set; }

    //Navigation Properties

    public Country? Country { get; set; }
    public ICollection<Address>? Addresses { get; set; } = new List<Address>();
    public ICollection<OrderDetails>? Orders { get; set; } = new List<OrderDetails>();
    public ICollection<Complaint>? Complaints { get; set; } = new List<Complaint>();
    public ShoppingBag? ShoppingBag { get; set; }

}

public enum Gender
{
    Male,Female
}
