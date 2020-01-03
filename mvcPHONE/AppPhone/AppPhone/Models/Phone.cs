using Newtonsoft.Json;

namespace AppPhone.Models
{
    public enum TypeContact
    {
        PhoneNumber,
        Email,
        Facebook,
        Twitter,
        LinkedIN
    }

    public class Phone
    {
        [JsonProperty("ContactID")]
        public int ContactID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Type")]
        public TypeContact Type { get; set; }
        [JsonProperty("ContactValue")]
        public string ContactValue { get; set; }
    }
}
