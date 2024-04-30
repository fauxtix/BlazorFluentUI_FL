using System;
using System.Collections.Generic;
using System.Text;

namespace EdamanFluentApi.Model
{
    public class Result
    {
        public Result() { }

        public Result(List<Hit> hits) {
            this.hits = hits;
        }
        public List<Hit> hits { get; set; }
    }
}
