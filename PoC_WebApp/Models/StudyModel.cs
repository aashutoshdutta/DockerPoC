using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PoC_WebApp.Models
{
    public class Study
    {
        [DataMember(Name = "projectid")]
        public int projectid { get; set; }

        [DataMember(Name = "projectname")]
        public string projectname { get; set; }

        [DataMember(Name = "updated_after")]
        public string updated_after { get; set; }
    }
}
