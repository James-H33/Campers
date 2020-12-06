using System;
using System.Collections.Generic;

namespace Campers.Helpers
{
    public static class ColorGenerator
    {
        public static List<string> colors = new List<string>
        {
            "#f7a8a8b8",
            "#f7cca8b8",
            "#a9f7a8b8",
            "#a8f7f0b8",
            "#a8c4f7b8",
            "#ada8f7b8",
            "#d9a8f7b8",
            "#f7a8e2b8",
            "#f7a8a8b8"
        };

        public static string GetRandomColor()
        {
            var rand = new Random();
            return colors[rand.Next(0, colors.Count)];
        }
    }
}