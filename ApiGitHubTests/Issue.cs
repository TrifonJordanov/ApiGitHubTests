using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGitHubTests
{
   public class Issue
    {
        public string title { get; set; }
        public string url { get; set; }
        public long id { get; set; }
        public int number { get; set; }
    }
}
