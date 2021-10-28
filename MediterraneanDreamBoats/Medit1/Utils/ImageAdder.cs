using System;
using System.IO;
using System.Threading.Tasks;
using Medit1.Models;
using Microsoft.AspNetCore.Http;

namespace Medit1.Utils
{
    public static class ImageAdder
    {

        public static async Task<Image> AddImage(IFormFile photoFile, Cruise cruise)
        {
            var imageName = $"{Guid.NewGuid().ToString()}_{photoFile.FileName}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/cruises", imageName);
            var stream = new FileStream(path, FileMode.Create);
            await photoFile.CopyToAsync(stream);
            var image = new Image() { Cruise = cruise, Path = imageName };
            return image;
        }
    }
}
