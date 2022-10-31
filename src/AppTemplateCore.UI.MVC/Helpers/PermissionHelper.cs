using AppTemplateCore.CrossCutting.Shared;
using System.Security.Claims;

namespace AppTemplateCore.Helpers
{
    public static class PermissionHelper
    {
        /// <summary>
        /// Check if Claims/value exists to User.
        /// </summary>
        /// <param name="claimName">Name of Claims (check case sensitive) - use <see cref="ClaimName"/></param>
        /// <param name="permissonValue">Permission to check (check case sensitive) - use <see cref="ClaimPermission"/></param>
        /// <returns></returns>
        public static bool IfClaim(string claimName, string permissonValue) => IfClaim(claimName, new string[] { permissonValue });

        /// <summary>
        /// Check if Claims/value exists to User.
        /// </summary>
        /// <param name="claimName">Name of Claims (check case sensitive) - use <see cref="ClaimName"/></param>
        /// <param name="permissonValue">Permission to check more than one param values (check case sensitive) - use <see cref="ClaimPermission"/></param>
        /// <returns></returns>
        public static bool IfClaim(string claimName, params string[] permissonValue)
        {
            if (string.IsNullOrEmpty(claimName))
                return false;

            var xHttpContext = new HttpContextAccessor().HttpContext;

            var identity = (ClaimsIdentity)xHttpContext!.User.Identity!;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);

            if (claim == null)
                return false;

            foreach (var item in permissonValue)
            {
                if (!claim.Value.Contains(item))
                    return false;
            }
            return true;
        }

        //----------------------- Admin -----------------------
        /// <summary>
        /// Validate if user is Admin with full claims C,R,U,D
        /// </summary>
        /// <returns>Bool</returns>
        public static bool ValidateAdmin_FullPerm()
        {
            return (IfClaim(ClaimName.ADMIN, new[] { ClaimPermission.CREATE, ClaimPermission.READ, ClaimPermission.UPDATE, ClaimPermission.DELETE }));
        }

        /// <summary>
        /// Validate if user is Admin with List permission
        /// </summary>
        /// <returns>Bool</returns>
        public static bool ValidateAdmin_ListPerm()
        {
            if (IfClaim(ClaimName.ADMIN, ClaimPermission.READ))
                return true;
            else
                return false;
        }
        //----------------------- Admin -----------------------


        //----------------------- Operator -----------------------
        /// <summary>
        /// Validate if user is Operator with full claims C,R,U,D
        /// </summary>
        /// <returns>Bool</returns>
        public static bool ValidateOperator_FullPerm()
        {
            return IfClaim(ClaimName.OPERATOR, new[] { ClaimPermission.CREATE, ClaimPermission.READ, ClaimPermission.UPDATE, ClaimPermission.DELETE });
        }
    }
}
