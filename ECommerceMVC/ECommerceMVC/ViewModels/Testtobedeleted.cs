using ECommerceMVC.Context;
using ECommerceMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace ECommerceMVC.ViewModels


{
    public class Testtobedeleted
    {

        EcommerceDbContext test = new EcommerceDbContext();


        public void Seeding()
        {
            Country egy = new Country();
            egy.Name = "Egypt";
            egy.Code = "+20";
            egy.Abbreviation = "EGY";

            test.Country.Add(egy);


            test.Customer.AddRange(new Customer
            {
                FirstName = "Ahmed ",
                LastName = "Salah ",
                DataOfBirth = new DateTime(15 / 01 / 1999),
                Gender = Gender.Male,
                CountryId = 1,
                MobileNumber = 911,
                UserName = "Gru",
                EmailAddress = "dssadasnd@gmail.com",

                Password = "ffffffffffffff",
                CreatedOnUtc = DateTime.UtcNow,

                HasShoppingBagItems = false,
                RequireReLogin = false,
                FailedLoginAttempts = 0



            });
            test.SaveChanges();

        }


    }
}
//public int Id { get; set; }
//public string FirstName { get; set; }
//public string LastName { get; set; }
//public DateTime DataOfBirth { get; set; }
//public Gender Gender { get; set; }

//[ForeignKey("CountryId")]
//public int CountryId { get; set; }
//public int MobileNumber { get; set; }
//public string UserName { get; set; }
//public string EmailAddress { get; set; }
//public string Password { get; set; }
//public DateTime CreatedOnUtc { get; set; }
//public bool IsDeleted { get; set; } = false;
//public DateTime? DeleteDate { get; set; }
//public bool IsActive { get; set; } = true;

////[ForeignKey("Address")]
//public int? ShippingAddressId { get; set; }
//public bool IsAdmin { get; set; } = false;
//public string? AdminComment { get; set; }
//public bool HasShoppingBagItems { get; set; }
//public bool RequireReLogin { get; set; }
//public int FailedLoginAttempts { get; se