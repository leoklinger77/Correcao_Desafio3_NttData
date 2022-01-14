using NttDataSupplier.Domain.Models.enums;
using System;

namespace NttDataSupplier.WebApp.Models.Supplier
{
    public class PhoneViewModel
    {
        public string Ddd { get; set; }
        public string Number { get; set; }
        public PhoneType PhoneType { get; set; }

    }
}
