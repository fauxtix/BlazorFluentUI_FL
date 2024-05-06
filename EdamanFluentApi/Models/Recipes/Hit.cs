using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdamanFluentApi.Models.Recipes
{
    public partial class Hit
    {
        [JsonProperty("recipe")]
        public Recipe Recipe { get; set; }
    }
}
