using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace NttDataSupplier.Domain.Interfaces.Services
{
    public interface IImageService
    {
        List<string> StoreImageTemporary(params IFormFile[] file);        
        void MoveTempToFixed (List<string> file);
    }
}
