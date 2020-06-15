using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UploadImgAPI.Models;
using UploadImgAPI.Services;
using UploadImgAPI.ViewModels;

namespace UploadImgAPI.Repositories
{
    public class ImgRepository
    {
        private HttpClient Client;
        private UrlKeyService Service;

        public ImgRepository()
        {
            this.Client = new HttpClient();
            this.Service = new UrlKeyService();
        }

        public async Task<RetornoJsonViewModel> UploadImg(ImgViewModel file)
        {
            var urlKeyService = Service.GetUrlAndKey();

            try
            {
                // Declaração de variavel byte
                byte[] imageData = null;

                // Abre uma leitura da imagem e transforma-a em uma stream (fluxo, corrente), após isso, cria uma classe de leitura binária
                var br = new BinaryReader(file.Img.OpenReadStream());
                // Transforma novamente a imagem em uma stream e usa como parametro, a propriedade Lenght (comprimento da stream), após isso lê todos os bytes do comprimento da stream e devolve uma matriz de bytes.
                imageData = br.ReadBytes((int)file.Img.OpenReadStream().Length);

                // Declaração de dados de multiplas partes, aceita variados dados para passar como parametro da requisição.
                // OBS. Seria como colocar na TAG <form> do HTML, uma propriedade "multipart/form-data" nos parametros.
                MultipartFormDataContent form = new MultipartFormDataContent();

                // Adiciona um parametro necessário para a requisição da api, chamada "key" (aqui seria a key da sua conta, dentro do site).
                form.Add(new StringContent(urlKeyService.Key), "key");
                // Adiciona a imagem em bytes (dados binários) como parametro.
                form.Add(new ByteArrayContent(imageData), "image", file.Img.FileName);
                // OBS. Esta API em especial, aceita dados baseados em 64 bits (base64), dados binários ou uma URL para a imagem.

                HttpResponseMessage resposta = await Client.PostAsync(urlKeyService.Url, form);

                if (!resposta.IsSuccessStatusCode)
                    throw new Exception("Ocorreu um erro na requisição à API.");

                // Propriedade Content guarda a resposta da requisição HTTP
                // Mapeia o objeto de resposta para RetornoJsonViewModel (mapeamento é representado pelos sinais de menor e igual <> seguido de parenteses)

                // Explicação da Sintaxe: após o método para ler assincronamente, dentro dos simbolos "<>" terá a classe de retorno do mapeamento e dentro dos parenteses, estará o objeto que será mapeado [...]
                // [...] Que neste caso, não é necessário para o nosso objetivo, pois estamos acessando o método de leitura com o próprio objeto de resposta da API.
                RetornoJsonViewModel retorno = await resposta.Content.ReadAsAsync<RetornoJsonViewModel>();

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }
    }
}
