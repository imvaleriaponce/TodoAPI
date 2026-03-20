namespace WebApplication_ejemplobd.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Value { get; set; }= String.Empty;
        public string Status { get; set; } = String.Empty;
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; } = String.Empty;

        public DateTime UpdateDate { get; set; }
    }
}
