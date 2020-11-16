using System;

namespace GQL_client.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public AccountType Type { get; set; }
        public string Description { get; set; }

    }

    public enum AccountType
    {
        Cash,
        Savings,
        Expense,
        Income,
    }
}
