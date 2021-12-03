using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApi.Models
{
    public partial class ArInternalMetadatum
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
