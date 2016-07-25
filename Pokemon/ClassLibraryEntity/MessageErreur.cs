using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class MessageErreur
    {
        [JsonProperty(PropertyName = "errors")]
        public List<String> messages { get; set; }

        public MessageErreur() { }
        
    }
}
