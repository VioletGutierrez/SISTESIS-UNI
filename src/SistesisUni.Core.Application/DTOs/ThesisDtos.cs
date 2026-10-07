namespace SistesisUni.Core.Application.DTOs
{
    public record CreateThesisDto(
        string Title,
        string AbstractText,
        string StudentId,
        string DocumentUrl
    );

    public record ThesisResponseDto(
        Guid Id,
        string Title,
        string AbstractText,
        string StudentId,
        string DocumentUrl,
        string Status,
        DateTime CreatedAt
    );
}