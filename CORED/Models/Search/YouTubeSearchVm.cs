using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORED.Models.Search
{
    public class YouTubeSearchVm
    {
        public string SearchTerm { get; set; }

        public int ResultCount { get; set; }

        public List<VideoVm> Results { get; set; }
    }

    //public YouTubeSearchVm()
    //{
    //    Results = new List<VideoVm>();
    //}

}
