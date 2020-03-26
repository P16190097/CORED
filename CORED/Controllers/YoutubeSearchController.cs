using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CORED.Models;
using CORED.Models.Search;
using Microsoft.Extensions.Options;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.YouTube.v3.Data;

namespace CORED.Controllers
{
    public class YoutubeSearchController : Controller
    {
        private readonly string _ApiKey;

        public YoutubeSearchController(IOptions<CoreConfig> settings)
        {
            _ApiKey = "AIzaSyAAuwCYk274y2qAtJ25XMpp_ZXUYhaJv7Q";
            //_ApiKey = settings.Value.YouTubeApiKey;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Search(string keyWord)
        {
            YouTubeSearchVm model = new YouTubeSearchVm();
            model.Results = new List<SearchResultVm>();

            var youtubeService = new YouTubeService(new BaseClientService.Initializer() {
                ApiKey = _ApiKey,
                ApplicationName = this.GetType().ToString()
            });

            SearchResource.ListRequest listRequest = youtubeService.Search.List("snippet");
            listRequest.Q = keyWord;
            listRequest.MaxResults = 10;
            listRequest.Type = "video";

            SearchListResponse resp = listRequest.Execute();

            foreach(var result in resp.Items)
            {
                SearchResultVm vid = new SearchResultVm();
                vid.Title = result.Snippet.Title;
                vid.Description = result.Snippet.Description;
                vid.Thumbnail = result.Snippet.Thumbnails.Default__.Url;
                vid.Channel = result.Snippet.ChannelTitle;
                vid.Live = result.Snippet.LiveBroadcastContent;
                vid.Url = result.Id.VideoId;
                model.Results.Add(vid);
            };

            model.SearchTerm = keyWord;
            model.ResultCount = resp.Items.Count;

            return View("YoutubeSearch", model);
        }

        public ActionResult Video(string url)
        {
            VideoVm model = new VideoVm();
            model.RelatedVideos = new List<SearchResultVm>();
            model.Url = url;

            //need to abstract code to helper class

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _ApiKey,
                ApplicationName = this.GetType().ToString()
            });

            SearchResource.ListRequest listRequest = youtubeService.Search.List("snippet");
            listRequest.RelatedToVideoId = url;
            listRequest.MaxResults = 10;
            listRequest.Type = "video";

            SearchListResponse resp = listRequest.Execute();

            foreach (var result in resp.Items)
            {
                SearchResultVm vid = new SearchResultVm();
                vid.Title = result.Snippet.Title;
                vid.Description = result.Snippet.Description;
                vid.Thumbnail = result.Snippet.Thumbnails.Default__.Url;
                vid.Channel = result.Snippet.ChannelTitle;
                vid.Live = result.Snippet.LiveBroadcastContent;
                vid.Url = result.Id.VideoId;
                model.RelatedVideos.Add(vid);
            };

            return View("WatchVideo", model);
        }
    }
}