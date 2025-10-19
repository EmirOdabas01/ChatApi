using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.BL.DTOs
{
    public class MessageResponseDto
    {
        public int Id { get; set; }
        public string userNickName { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Sentiment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
