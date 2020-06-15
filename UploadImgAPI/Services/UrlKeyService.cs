using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadImgAPI.ViewModels;

namespace UploadImgAPI.Services
{
    public class UrlKeyService
    {
        public UrlKeyViewModel GetUrlAndKey()
        {
            string arquivo = "";

            try
            {
                arquivo = File.ReadAllText("./Services/Files/url_key_imgbb.json");
            }
            catch (Exception)
            {
                return null;
            }

            if (string.IsNullOrEmpty(arquivo))
                return null;

            //Mapeia para arquivo correspondente ao json
            var retorno = JsonConvert.DeserializeObject<UrlKeyViewModel>(arquivo);

            return retorno;
        }
    }
}
