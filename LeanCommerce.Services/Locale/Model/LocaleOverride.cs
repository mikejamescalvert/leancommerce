using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Locale.Model
{
    public class LocaleOverride
    {
        public ObjectId Id { get; set; }
        public string LocaleId { get; set; }
        public string OverrideReference { get; set; }
        public string Override { get; set; }
    }
}
