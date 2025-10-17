using ChatApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.DA
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatApiContext _chatApiContext;
        private readonly DbSet<User> _users;

        public UserRepository(ChatApiContext chatApiContext)
        {
            _chatApiContext = chatApiContext;
            _users = _chatApiContext.Set<User>();
        }

        public async Task<int> AddAsync(User user)
        {
            var entityEntry = await _users.AddAsync(user);
            await _chatApiContext.SaveChangesAsync();

            var newUser= await _users.FirstOrDefaultAsync(u => u.NickName == user.NickName);

            if(newUser != null)
                return newUser.Id;
            return -1;
        }

        public async Task<List<Message>> GetUserMessages(int id)
        {
            var user = await _users.Where(u => u.Id == id).Include(u => u.Messages).FirstOrDefaultAsync();
            if(user != null)
            {
                return user.Messages.ToList();
            }

            return null;
        }
    }
}
