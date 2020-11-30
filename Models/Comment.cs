using System;
using System.Text.Json.Serialization;

namespace Campers.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [JsonPropertyName("comment")]
        public string Message { get; set; } = "";

        public string Username { get; set; } = "";

        public DateTime DateCreated { get; set; }
    }
}