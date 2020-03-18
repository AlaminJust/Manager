using LocalMealManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Services
{
    public interface IAccountRepository
    {
        public Task<Boolean> AddBalance(AccountViewModel model , string AddedBy);
    }
}
