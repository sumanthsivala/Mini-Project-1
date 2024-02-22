namespace OnlineBankingSystem.Models
{
    public class UpdateCustomerViewModel
    {

        public Guid Id{ get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }

        public string CustomerType {  get; set; }
    }
}
