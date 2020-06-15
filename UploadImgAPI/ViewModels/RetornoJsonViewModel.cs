using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImgAPI.ViewModels
{
    // Objeto original retornado da API imgBB
    // Construção de cada objeto, para transforma-lo em um só (classe abaixo RetornoJsonViewModel), para a realização do mapeamento na hora de ler o retorno da api.
    public class RetornoJsonViewModel
    {
        [JsonProperty(PropertyName = "data")]
        public DataResult Data { get; set; }
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }

    public class DataResult
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "image")]
        public ImageResult Image { get; set; }
        [JsonProperty(PropertyName = "thumb")]
        public ThumbResult Thumb { get; set; }
        [JsonProperty(PropertyName = "medium")]
        public MediumResult Medium { get; set; }
    }

    public class ImageResult
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }
    }

    public class ThumbResult
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }
    }

    public class MediumResult
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }
    }
}
