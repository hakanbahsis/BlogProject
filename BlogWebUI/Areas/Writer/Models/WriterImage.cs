namespace BlogWebUI.Areas.Writer.Models
{
    public class WriterImage
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string SenderName { get; set; }
        public string Receiver { get; set; }
        public string MessageContent { get; set; }
        public string ImageUrl { get; set; }
    }
}
