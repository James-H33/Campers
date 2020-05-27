using System;

namespace Campers.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}