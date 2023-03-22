namespace MIS.IntegrationTests.Base
{
    internal static class CharacterSets
    {
        public const string Numeric = "0123456789";

        public const string Alphabetical = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public const string SpecialCharacters = "~`!@#$%^&*()-_+=[]{}\\|;:'\",.<>/? ";

        public const string Alphanumeric = Numeric + Alphabetical;

        public const string AplhanumericWithSpecialCharacters = Alphanumeric + SpecialCharacters;
    }
}
