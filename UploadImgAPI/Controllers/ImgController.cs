using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadImgAPI.Models;
using UploadImgAPI.Repositories;

namespace UploadImgAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ImgController : ControllerBase
    {
        public ImgRepository imgRepository { get; set; }

        public ImgController()
        {
            imgRepository = new ImgRepository();
        }

        [HttpPost("UploadImg")]
        public IActionResult UploadImg([FromForm] ImgViewModel input)
        {
            try
            {
                var retorno = imgRepository.UploadImg(input);

                return StatusCode(200, retorno.Result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
