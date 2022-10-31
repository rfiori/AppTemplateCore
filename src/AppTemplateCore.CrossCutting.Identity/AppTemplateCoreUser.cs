using Microsoft.AspNetCore.Identity;

namespace AppTemplateCore.CrossCutting.Identity
{
    // Add profile data for application users by adding properties to the AppTemplateCoreUser class
    public class AppTemplateCoreUser : IdentityUser
    {
        /// <summary>
        /// Full name.
        /// </summary>
        [ProtectedPersonalData]
        public string? FullName { get; set; }

        /// <summary>
        /// Date of birth.
        /// </summary>
        public DateTime? DOB { get; set; }

        /// <summary>
        /// Date on create record.
        /// </summary>
        public DateTime? CreateOn { get; set; }
    }
}
