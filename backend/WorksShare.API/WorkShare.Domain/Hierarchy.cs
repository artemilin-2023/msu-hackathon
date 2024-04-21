namespace WorkShare.Domain
{
    public class Hierarchy
    {

        public string WorkType {  get; private set; }
        public string Subject { get; private set; }
        public int Course { get; private set; }

        public Hierarchy(string workType, string subject, int course)
        {
            if (string.IsNullOrEmpty(workType)) throw new Exception(nameof(workType));
            if (string.IsNullOrEmpty(subject)) throw new Exception(nameof(subject));
            if (course <= 0 || course > 8) throw new ArgumentOutOfRangeException(nameof(course));

            WorkType = workType;
            Subject = subject;
            Course = course;
        }
    }
}