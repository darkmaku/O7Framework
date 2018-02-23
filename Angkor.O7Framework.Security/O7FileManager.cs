using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Angkor.O7Framework.Common.Model;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace Angkor.O7Framework.Utility
{
    public static class O7FileManager
    {
        private static readonly string Apikey = WebConfigurationManager.AppSettings["O7WEB_FILE_API_KEY"];
        private static string Host = WebConfigurationManager.AppSettings["O7WEB_FILE_HOST"];


        public static string InsertFileFromEncode64(string file, string newfilename)
        {
            try
            {
                byte[] fileData = Convert.FromBase64String(file);
                var route = newfilename;
                if (UploadFile(route, fileData) == 0)
                    return route;
                return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public static string Update(HttpPostedFileBase file, string newfilename)
        {
            try
            {
                if (file.ContentLength != 0)
                {
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(file.ContentLength);
                    }

                    var filename = file.FileName;
                    var extension = Path.GetExtension(filename).ToLower();
                    var route = newfilename + extension;
                    if (UploadFile(route, fileData) == 0)
                        return route;
                    return "";
                }
                return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public static Stream DownloadFileStream(string filepath)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(Host + "/files");
                request.Headers["apikey"] = Apikey;
                request.Headers["filename"] = filepath;
                request.Method = "GET";
                request.ContentType = "application/json";
                request.ContentLength = 0;
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                var obj = JObject.Parse(responseString);
                var content = (string)obj["content"];
                byte[] data = Convert.FromBase64String(content);
                MemoryStream stream = new MemoryStream(data);
                if (stream == null)
                    return new MemoryStream();
                return stream;
            }
            catch (Exception e)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(filepath);
                    request.Method = "GET";
                    var response = (HttpWebResponse)request.GetResponse();
                    var streamReader = new StreamReader(response.GetResponseStream());
                    var bytes = default(byte[]);
                    using (var memstream = new MemoryStream())
                    {
                        streamReader.BaseStream.CopyTo(memstream);
                        bytes = memstream.ToArray();
                    }

                    MemoryStream stream = new MemoryStream(bytes);
                    if (stream == null)
                        return new MemoryStream();
                    return stream;

                }
                catch (Exception exception)
                {
                    return null;

                }
            }
        }

        public static string GellFullUrlPath(string path)
        {
            if (path == "")
                return "";
            return "/Shared/File/GetFile?url=" + path.Replace("/", "%2f").Replace("\\", "%2f");
        }

        public static string GetFullUrlHost(string path, string hostWeb)
        {
            if (path == "")
                return "";
            return hostWeb + "/Shared/File/GetFile?url=" + path.Replace("/", "%2f").Replace("\\", "%2f");
        }

        public static string DeleteFile(string filepath)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(Host + "/files");
                request.Headers["apikey"] = Apikey;
                request.Headers["filename"] = filepath;
                request.Method = "DELETE";
                request.ContentType = "application/json";
                request.ContentLength = 0;
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                var obj = JObject.Parse(responseString);
                return "true";
            }
            catch (Exception e)
            {
                return "false";
            }
        }
        public static string DownloadFile(string filepath)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(Host + "/files");
                request.Headers["apikey"] = Apikey;
                request.Headers["filename"] = filepath;
                request.Method = "GET";
                request.ContentType = "application/json";
                request.ContentLength = 0;
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                var obj = JObject.Parse(responseString);
                var content = (string)obj["content"];
                string mimeType = MimeMapping.GetMimeMapping(filepath);
                return "data:" + mimeType + "; base64," + content;
            }
            catch (Exception e)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(filepath);
                    request.Method = "GET";
                    var response = (HttpWebResponse)request.GetResponse();
                    var streamReader = new StreamReader(response.GetResponseStream());
                    //String content = Convert.ToBase64String(response);

                    var bytes = default(byte[]);
                    using (var memstream = new MemoryStream())
                    {
                        streamReader.BaseStream.CopyTo(memstream);
                        bytes = memstream.ToArray();
                    }

                    String content = Convert.ToBase64String(bytes);

                    string mimeType = MimeMapping.GetMimeMapping(filepath);
                    return "data:" + mimeType + "; base64," + content;

                }
                catch (Exception exception)
                {
                    return "";

                }
            }
        }


        public static int UploadFile(string filepath, byte[] fileData)
        {
            try
            {
                String content = Convert.ToBase64String(fileData);
                var request = (HttpWebRequest)WebRequest.Create(Host + "/files");
                O7SystemFile file = new O7SystemFile();
                file.Name = filepath;
                file.Content = content;
                request.Headers["apikey"] = Apikey;
                JavaScriptSerializer js = new JavaScriptSerializer();
                js.MaxJsonLength = 999999999;
                var data = Encoding.ASCII.GetBytes(js.Serialize(file));

                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }

        }


    }
}
