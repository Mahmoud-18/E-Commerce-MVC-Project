using ECommerceMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.ViewModels;

public class RegisterViewModel
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    public int CountryId { get; set; }
    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string PhoneNumber { get; set; }

    public string ZipCode { get; set; }

    public string CountryDialCode { get; set; }

    public DateTime DataOfBirth { get; set; }
    public Gender Gender { get; set; }


}
