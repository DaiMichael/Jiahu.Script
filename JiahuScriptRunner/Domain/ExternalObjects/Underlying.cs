namespace JiahuScriptRunner.Domain.ExternalObjects
{
    public class Underlying
    {
        public string[] Countries { get; set; }
        public Currency[] Currencies { get; set; }
        public decimal[] Strikes { get; set; }
        public string[] BbgCodes { get; set; }
        public string[] BbgCodesShort { get; set; }
        public string[] Rics { get; set; }
        public string[] Isins { get; set; }
        public string[] ShortNames { get; set; }
        public string[] LongNames { get; set; }
        public Exchange[] Exchanges { get; set; }
        public string[] RelatedExchanges { get; set; }
        public string[] Regions { get; set; }
        public string[] AssetTypes { get; set; }
        public string Tenor { get; set; }
        public string LongTenor { get; set; }
        public string FloatRateOption { get; set; }
        public int FxLag { get; set; }
        public int FxBusinessDays { get; set; }

        public Exchange GetMainExchange()
        {
            return Exchanges.Length == 0 ? new Exchange() : Exchanges[0];
        }
    }
}
