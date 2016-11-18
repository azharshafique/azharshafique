using System;
using System.Collections.Generic;

namespace HotTrends.Models
{
    public partial class Videopost
    {
        public int VideoId { get; set; }
        public string VideoCategory { get; set; }
        public string VideoDiscription { get; set; }
        public string VideoEmbed { get; set; }
        public string VideoName { get; set; }
    }
}
