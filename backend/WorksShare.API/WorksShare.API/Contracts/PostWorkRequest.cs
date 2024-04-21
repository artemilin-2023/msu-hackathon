using System.ComponentModel.DataAnnotations;

namespace WorksShare.API.Contracts
{
    public record Hierarchy(
        [Required][Range(1, 6)] int Course, 
        [Required] string Subject,
        [Required] string WorkType);

    public record PostWorkRequest
    {
        [Required]
        public Hierarchy Hierarchy { get; set; }
        [Required]
        public string Name { get; set; }

        [Required][MinLength(1)]
        public IFormFileCollection Files { get; set; }
    }
}
