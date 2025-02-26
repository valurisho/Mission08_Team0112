namespace Mission08_Team0112.Models
{
    public class TaskViewModel
    {
        public string TaskName { get; set; }
        public DateTime? DueDate { get; set; }
        public int Quadrant { get; set; }
        public int CategoryId { get; set; }
        public bool Completed { get; set; }
    }
}