using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORED.Models.Search
{
    public class VideoVm
    {
        public string Url { get; set; }

        public List<SearchResultVm> RelatedVideos { get; set; }
    }
}
