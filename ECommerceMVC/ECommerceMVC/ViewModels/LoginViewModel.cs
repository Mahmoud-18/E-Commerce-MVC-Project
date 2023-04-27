using System.ComponentModel;

namespace ECommerceMVC.ViewModels;

public class LoginViewModel
{
    public string UserName { get; set; }
    public string Password { get; set; }

    [DisplayName("Rememeber Me")]
    public bool RememberMe { get; set; }
}
