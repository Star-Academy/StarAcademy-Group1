using System;

namespace Models.Banking
{
    public class Transaction : AmountedEntity<string, string>
    {
        public override string Id { get; set; }
        public override string Source { get; set; }
        public override string Target { get; set; }
        public override Int64 Amount { get; set; }
        public Int64 Date { get; set; }
        public int Time { get; set; }
        public int TrackingId { get; set; }
        public string Type { get; set; }
    }
}