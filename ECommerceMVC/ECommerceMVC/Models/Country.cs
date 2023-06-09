﻿namespace ECommerceMVC.Models;

public class Country
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;

    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedOnUtc { get; set; }

    //Navigation Properties
    public ICollection<Customer>? Customers { get; set; } = new List<Customer>();
    public ICollection<Address>? Addresses { get; set; } = new List<Address>();
}
