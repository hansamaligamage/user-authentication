using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace userAuthentication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public bool IsActive { get; set; }

        public string DisplayName { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public ApplicationUser () : base ()
        {
            PasswordHistory = new List<PasswordHistory>();
        }

        public virtual List<PasswordHistory> PasswordHistory { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Account> Accounts { get; set; }

    }

    public class PasswordHistory
    {
        public PasswordHistory()
        {
            CreatedDate = DateTime.Now;
        }

        public DateTime CreatedDate { get; set; }

        [Key, Column(Order = 1)]
        public string PasswordHash { get; set; }

        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }

}