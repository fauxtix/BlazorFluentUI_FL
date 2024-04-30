using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdamanFluentApi.Model
{
    public partial class Hit
    {
        [JsonProperty("recipe")]
        public Recipe Recipe { get; set; }
    }
}
