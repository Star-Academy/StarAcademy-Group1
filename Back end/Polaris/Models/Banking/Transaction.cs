namespace Models.Banking
{
    public class Transaction : Entity<string>
    {
        public override string Id { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string Timestamp { get; set; }
        public int TrackingId { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
    }
}