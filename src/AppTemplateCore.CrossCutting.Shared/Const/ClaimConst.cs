namespace AppTemplateCore.CrossCutting.Shared
{
    public static class ClaimPermission
    {
        //public const string Listing = "L";
        /// <summary>
        /// Create Record
        /// </summary>
        public const string CREATE = "C";
        /// <summary>
        /// Read Records
        /// </summary>
        public const string READ = "R";
        /// <summary>
        /// Update Records
        /// </summary>
        public const string UPDATE = "U";
        /// <summary>
        /// Delete Records
        /// </summary>
        public const string DELETE = "D";

        /// <summary>
        /// Represents "C-R-U-D"
        /// </summary>
        public static string FullAccess
        {
            get
            {
                return $"{CREATE}-{READ}-{UPDATE}-{DELETE}";
            }
        }
    }

    public static class ClaimName
    {
        /// <summary>
        /// System Admim
        /// </summary>
        public const string ADMIN = "ADMIN";

        /// <summary>
        /// Permission to user operator
        /// </summary>
        public const string OPERATOR = "OPRT";
    }
}