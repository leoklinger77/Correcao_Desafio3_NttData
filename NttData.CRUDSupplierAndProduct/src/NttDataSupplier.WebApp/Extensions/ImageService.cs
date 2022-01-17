using Microsoft.AspNetCore.Http;
using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NttDataSupplier.WebApp.Extensions
{
    public class ImageService : IImageService
    {
        private readonly INotificationService _notificationService;

        public ImageService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task DeleteImage(List<string> file)
        {
            foreach (var item in file)
            {
                var fileExist = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/product/{item}");

                if (!File.Exists(fileExist))
                {
                    _notificationService.AddErro("Ocorreu um erro ao salvar uma das fotos.");
                }
                File.Delete(fileExist);
            }
            await Task.CompletedTask;
        }

        public void MoveTempToFixed(List<string> file)
        {
            foreach (var item in file)
            {
                var filePathSource = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/temp/{item}");
                var filePathDestination = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/product/{item}");
                if (!File.Exists(filePathSource))
                {
                    _notificationService.AddErro("Ocorreu um erro ao salvar uma das fotos.");                    
                }
                File.Move(filePathSource, filePathDestination);
            }            
        }

        public List<string> StoreImageTemporary(params IFormFile[] file)
        {
            List<string> list = new List<string>();
            foreach (var item in file)
                if (item != null && item.Length > 0)
                {
                    var path = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);
                    SaveImage(item, $"wwwroot/images/temp/{path}");
                    list.Add(path);
                }

            return list;
        }

        private bool SaveImage(IFormFile file, string path)
        {
            if (file == null || file.Length == 0)
            {
                _notificationService.AddErro("Imagem não informada.");
                return false;
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path);
            if (File.Exists(filePath))
            {
                _notificationService.AddErro("Imagem informada já existe.");
                return false;
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
               file.CopyTo(stream);
            }
            return true;
        }        
    }
}
