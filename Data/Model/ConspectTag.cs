namespace CourseProject.Data.Model
{
    public class ConspectTag
    {
        public int ConspectId { get; set; }

        public Conspect Conspect { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
