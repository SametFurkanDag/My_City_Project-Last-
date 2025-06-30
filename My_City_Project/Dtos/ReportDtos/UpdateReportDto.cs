namespace My_City_Project.Dtos.ReportDtos
{
    public class UpdateReportDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ReportDate { get; set; } = DateTime.UtcNow;

    }
}
