using ChatApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.DA.Interfaces
{
    public interface IUserRepository
    {
        Task<int> AddAsync(User user);
        Task<List<Message>> GetUserMessages(int id);
    }
}
