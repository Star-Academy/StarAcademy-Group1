namespace Models.Banking
{
    public class BankAccount : Entity<string>
    {
        public override string Id { get; set; }
        public string CardId { get; set; }
        public string Sheba { get; set; }
        public string AccountType { get; set; }
        public string BranchTelephone { get; set; }
        public string BranchAdress { get; set; }
        public string BranchName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerFamilyName { get; set; }
        public string OwnerId { get; set; }
    }
}