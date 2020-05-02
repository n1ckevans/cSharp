using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccounts.Models
{
    public class TransactionViewModel
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Transaction Transaction { get; set; }
        public User User { get; set; }
    }
}