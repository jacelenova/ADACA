namespace ADACA
{
    public static class Constants
    {
        public static class Validation
        {
            public const decimal MIN_LOAN_EXCLUSIVE = 10;
            public const decimal MAX_LOAN_EXCLUSIVE = 100;
            public const int MIN_TIME_TRADING_EXCLUSIVE = 1;
            public const int MAX_TIME_TRADING_EXCLUSIVE = 20;
            public const string CITIZEN = "Citizen";
            public const string PERMANENT_RESIDENT = "Permanent Resident";
            public static readonly string[] ALLOWED_CITIZEN_STATUS = { CITIZEN, PERMANENT_RESIDENT };
        }

        public static class Decision
        {
            public const string QUALIFIED = "Qualified";
            public const string UNKNOWN = "Unknown";
            public const string UNQUALIFIED = "Unqualified";
        }
    }
}
