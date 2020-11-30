using System;
using System.Text.Json.Serialization;

namespace Campers.Models
{
    public class CommentForCreate
    {
        public int UserId { get; set; }

        public string Comment { get; set; } = "";
    }
}