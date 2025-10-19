using ChatApi.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.BL.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUserAsync(string Nickname);
        Task<List<MessageResponseDto>> GetAllAsync(int id);
    }
}
