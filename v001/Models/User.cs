using Microsoft.AspNetCore.Identity;

namespace v001.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string Patronymic { get; set; }
}