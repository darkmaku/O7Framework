using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace Angkor.O7Framework.Common.Model
{
    public class O7MailMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Cco { get; set; }
        public string StrCc { get; set; }
        public string StrCco { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<Attachment> Attachments { get; set; }

        public void AddAttachment(Stream stream, string filename)
        {
            if (Attachments == null)
            {
                Attachments = new List<Attachment>();
            }
            Attachments.Add(new Attachment(stream, filename));
        }

        public void AddAttachment(String url, string filename)
        {
            if (Attachments == null)
            {
                Attachments = new List<Attachment>();
            }
            var stream = GetStreamFromUrl(url);
            Attachments.Add(new Attachment(stream, filename));
        }

        private static Stream GetStreamFromUrl(string url)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
                imageData = wc.DownloadData(url);

            return new MemoryStream(imageData);
        }
    }
}
