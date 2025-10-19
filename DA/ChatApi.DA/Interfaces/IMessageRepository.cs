using ChatApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.DA.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllAsync();
        Task<bool> AddAsync(Message model);
        Task<int> SaveAsync();
    }
}
