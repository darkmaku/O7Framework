using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace Angkor.O7Framework.Common.Model
{
    public class O7SystemFile
    {

        public string FileId { get; set; }
        public string Description { get; set; }
        public string ToolTip { get; set; }
        public string Content { get; set; }
        public string SystemId { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }
        public string DownloadUrl { get; set; }
        public string DeleteUrl { get; set; }

    }
}
