namespace BankApp.MVC.Infrastructures.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int ApplicationUserId { get; set; }

        //navigation props begin
        public ApplicationUser ApplicationUser { get; set; }
    }
}
