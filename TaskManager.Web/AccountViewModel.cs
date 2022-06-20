using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.Web
{
    public class AccountViewModel: User
    {
        public string Password { get; set;}
    }
}
