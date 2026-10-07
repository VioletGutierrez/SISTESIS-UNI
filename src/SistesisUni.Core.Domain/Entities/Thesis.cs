namespace SistesisUni.Core.Domain.Entities
{
    public enum ThesisStatus
    {
        Submitted = 1,
        UnderReview = 2,
        Approved = 3,
        Rejected = 4
    }

    public class Thesis
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string AbstractText { get; private set; }
        public string StudentId { get; private set; }
        public string DocumentUrl { get; private set; }
        public ThesisStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Thesis(string title, string abstractText, string studentId, string documentUrl)
        {
            Id = Guid.NewGuid();
            Title = title ?? throw new ArgumentNullException(nameof(title));
            AbstractText = abstractText ?? throw new ArgumentNullException(nameof(abstractText));
            StudentId = studentId ?? throw new ArgumentNullException(nameof(studentId));
            DocumentUrl = documentUrl ?? throw new ArgumentNullException(nameof(documentUrl));
            Status = ThesisStatus.Submitted;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateStatus(ThesisStatus newStatus) => Status = newStatus;
    }
}