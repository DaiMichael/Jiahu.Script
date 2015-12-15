namespace JiahuScriptRunner.Domain.ExternalObjects
{
    public class Exchange
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public string GetFullName()
        {
            return Name + " - " + Country;
        }
    }
}