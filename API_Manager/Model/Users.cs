using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Manager.Model
{
    [Table("Users")]
    public class Users
    {
        [Key]
        /*[SwaggerSchema(WriteOnly = true)]*/
        [JsonIgnore]
        public int id { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String pass { get; set; }
    }
}
