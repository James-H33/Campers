using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Campers.Helpers;

namespace Campers.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [JsonPropertyName("comment")]
        public string Message { get; set; } = "";

        public string Username { get; set; } = "";

        public DateTime DateCreated { get; set; }

        public string ProfileBackgroundColor { get; set; } = "";

        public Comment()
        {
            ProfileBackgroundColor = ColorGenerator.GetRandomColor();
        }
    }
}