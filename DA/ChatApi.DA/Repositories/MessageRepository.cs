using ChatApi.Core.Entities;
using ChatApi.DA.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.DA.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatApiContext _chatApiContext;
        private readonly DbSet<Message> _messages;

        public MessageRepository(ChatApiContext chatApiContext)
        {
            _chatApiContext= chatApiContext;
            _messages= _chatApiContext.Set<Message>();
        }
        public async Task<bool> AddAsync(Message model)
        {
            var entityEntry = await _messages.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<List<Message>> GetAllAsync()
         =>  await _messages.OrderBy(m => m.CreatedAt).Include(m => m.User).ToListAsync();

        public async Task<int> SaveAsync()
         => await _chatApiContext.SaveChangesAsync();
    }
}
