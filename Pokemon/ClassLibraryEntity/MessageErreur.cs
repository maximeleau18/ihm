using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class MessageErreur : EntityBase
    {
        [JsonProperty(PropertyName = "errors_login")]
        public List<String> messagesErreursLogin { get; set; }

        [JsonProperty(PropertyName = "errors_password")]
        public List<String> messagesErreursPassword { get; set; }

        public MessageErreur() { }
        
    }
}
