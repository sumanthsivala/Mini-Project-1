namespace OnlineBankingSystem.Models.Domain
{
    public class Customer
    {
        public Guid Id{ get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }


        public string CustomerType { get; set; }
    }
}
