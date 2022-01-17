using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Services
{
    public interface IImageService
    {
        List<string> StoreImageTemporary(params IFormFile[] file);        
        void MoveTempToFixed (List<string> file);
        Task DeleteImage(List<string> file);
    }
}
