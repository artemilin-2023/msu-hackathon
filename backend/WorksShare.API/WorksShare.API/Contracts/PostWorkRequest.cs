using System.ComponentModel.DataAnnotations;

namespace WorksShare.API.Contracts
{
    public record Hierarchy(int Course, string Subject, string WorkType);

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
