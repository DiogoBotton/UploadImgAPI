using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImgAPI.Models
{
    public class ImgViewModel
    {
        [Required]
        public IFormFile Img { get; set; }

        public ImgViewModel()
        {

        }
    }
}
