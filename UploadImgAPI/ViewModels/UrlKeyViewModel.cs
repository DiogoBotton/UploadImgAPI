using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImgAPI.ViewModels
{
    public class UrlKeyViewModel
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        public UrlKeyViewModel()
        {

        }
    }
}
