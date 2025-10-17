using ChatApi.BL.DTOs;
using ChatApi.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.BL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddUserAsync(string Nickname)
        {
            var id = await _userRepository.AddAsync(new Core.Entities.User { NickName = Nickname });
            return id;
        }

        public async Task<List<MessageResponseDto>> GetAllAsync(int id)
        {

            var messages = await _userRepository.GetUserMessages(id);
            
            return messages.Select(m => new MessageResponseDto
            {
                Id = m.Id,
                Text = m.Text,
                Sentiment = m.Sentiment,
                CreatedAt = m.CreatedAt,
            }).ToList();
        }
    }
}
