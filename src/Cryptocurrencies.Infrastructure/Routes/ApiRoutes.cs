namespace Cryptocurrencies.Infrastructure.Routes;

public static class ApiRoutes
{
    public static class CoinCap
    {
        public const string Base = "https://api.coincap.io/v2/";
        
        public const string Coins = "assets";
        public const string Coin = "assets/{id}";
        public const string CoinHistory = "assets/{id}/history";
        public const string Markets = "assets/{id}/markets";
        public const string Rates = "rates";
        public const string Rate = "rates/{id}";
    }
}