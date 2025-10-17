using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.BL.DTOs
{
    public class CreateMessageDto
    {
        public int UserId { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
