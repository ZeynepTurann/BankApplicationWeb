namespace BankApp.MVC.Models
{
    public class AccountCreateModel
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int ApplicationUserId { get; set; }
    }
}

