using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplikacja_muzyczna.Models
{
    public class AddComment
    {
        public string Content { get; set; }
        public int PerformanceId { get; set; }
        public string Author { get; set; }
        public DateTimeOffset DateofHide { get; set; }
        public string Moderator { get; set; }
        
    }
}