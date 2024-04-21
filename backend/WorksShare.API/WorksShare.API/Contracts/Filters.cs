using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WorksShare.API.Contracts
{
    public record Filters(
        [MaybeNull][Range(0, 6)] int? Course,
        [MaybeNull] string Name,
        [MaybeNull] string WorkType,
        [MaybeNull] string Subject,
        [Required][Range(0, 30)] int Limit
        );
}
