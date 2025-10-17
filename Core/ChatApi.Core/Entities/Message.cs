using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Sentiment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
