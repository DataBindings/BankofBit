using BankOfBIT_JP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplication
{
    /// <summary>
    /// given:TO BE MODIFIED
    /// this class is used to capture data to be passed
    /// among the windows forms
    /// </summary>
    public class ConstructorData
    {
        public BankAccount BankAccountEntity { get; set; }

        public Client ClientEntity { get; set; }
    }
}
