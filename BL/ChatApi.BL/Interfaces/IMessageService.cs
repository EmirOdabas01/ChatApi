using ChatApi.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.BL.Interfaces
{
    public interface IMessageService
    {
        Task<List<MessageResponseDto>> GetAllAsync();
        Task<MessageResponseDto> AddAsync(CreateMessageDto dto);
    }
}
