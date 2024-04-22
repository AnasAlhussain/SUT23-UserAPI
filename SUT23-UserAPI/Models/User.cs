using System.ComponentModel.DataAnnotations;

namespace SUT23_UserAPI.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
