using System.ComponentModel.DataAnnotations;

namespace Learn.D2.api.Models.Settings
{
    public class FirebaseSettings
    {
        [Required]
        public string ProjectId { get; set; } =string.Empty;

        [Required]
        public string ApiKey { get; set; } =string.Empty;
    }
}
