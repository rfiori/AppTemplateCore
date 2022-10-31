using AppTemplateCore.CrossCutting.Shared;

namespace AppTemplateCore.Configuration
{
    public static class PolicyConfig
    {
        public static void AddPolicyConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAuthorization(opt => opt.AddPolicy(ClaimName.ADMIN, apb => apb.RequireClaim(ClaimName.ADMIN)));
        }
    }
}
