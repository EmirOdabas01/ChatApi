using ChatApi.BL.DTOs;
using ChatApi.Core.Entities;
using ChatApi.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ChatApi.BL
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly HttpClient _httpClient;

        public MessageService(IMessageRepository messageRepository, HttpClient httpClient)
        {
            _messageRepository = messageRepository;
            _httpClient = httpClient;
        }
        public async Task<MessageResponseDto> AddAsync(CreateMessageDto dto)
        {

            var sentiment = await AnalyzeSentimentWithHuggingFace(dto.Text);

            var message = new Message
            {
                Text = dto.Text,
                Sentiment = sentiment,
                UserId = dto.UserId
            };

            await _messageRepository.AddAsync(message);
            await _messageRepository.SaveAsync();

            return new MessageResponseDto
            {
                Id = message.Id,
                Text = message.Text,
                Sentiment = message.Sentiment,
                CreatedAt = message.CreatedAt
            };
        }

        private class AIResponse
        {
            public List<object>? data { get; set; }
        }

        private async Task<string> AnalyzeSentimentWithHuggingFace(string text)
        {
            try
            {
                var apiUrl = "http://127.0.0.1:8000/predict";

                var requestData = new
                {
                    text = text
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<HuggingFaceResponse>(responseContent);

                    if (result != null && result.sentiment != null && result.sentiment.Length > 0)
                    {
                        return result.sentiment;
                    }
                }
                else
                {
                    Console.WriteLine($"Hugging Face API Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log error but don't fail the message sending
                Console.WriteLine($"Hugging Face sentiment analysis failed: {ex.Message}");
            }

            return "neutral"; // Fallback sentiment
        }
        public class HuggingFaceResponse
        {
            public string sentiment { get; set; }
        }
    

        public async Task<List<MessageResponseDto>> GetAllAsync()
        {
            var messages = await _messageRepository.GetAllAsync();
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
