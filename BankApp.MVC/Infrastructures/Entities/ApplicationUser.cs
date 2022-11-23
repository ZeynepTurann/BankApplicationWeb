using System.Collections.Generic;

namespace BankApp.MVC.Infrastructures.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //relational props begin
        public List<Account> Accounts { get; set; }
    }
}
