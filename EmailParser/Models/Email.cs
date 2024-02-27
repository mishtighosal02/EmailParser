namespace EmailParser.Models
{
    public class Email
    {
        public List<String> to {  get; set; }
        public String from { get; set; }
        public List<String> cc { get; set; }
        public String subject { get; set; }
        public String textbody { get; set; }
        public String htmlbody { get; set; }
        public List<byte[]> attachments { get; set; }

        public Email()
        {
            to = new List<String>();
            cc = new List<String>();
            attachments = new List<byte[]>();
        }
    }
}
