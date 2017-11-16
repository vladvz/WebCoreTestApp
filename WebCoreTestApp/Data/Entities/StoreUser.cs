using Microsoft.AspNetCore.Identity;

namespace WebCoreTestApp.Data.Entities
{
    public class StoreUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
