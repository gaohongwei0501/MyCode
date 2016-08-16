using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace GHW.Test.App_Start
{
    public class AutoAddFilter : System.Web.IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PostRequestHandlerExecute += new EventHandler(this.OnPreSendRequestContent);
        }
        protected void OnPreSendRequestContent(Object sender, EventArgs e)
        {
            System.Web.HttpApplication myContext = (System.Web.HttpApplication)sender;
            myContext.Response.Filter = new AppendSIDFilter(myContext.Response.Filter);
        }
        private void ReUrl_BeginRequest(object sender, EventArgs e)
        {
            string cid = "";
            string url = "";
            HttpContext context = ((HttpApplication)sender).Context;
            if (string.IsNullOrEmpty(context.Request.QueryString["cid"]))
            {
                if (context.Request.QueryString.Count == 0)
                {
                    url = string.Format("{0}?cid={1}", context.Request.RawUrl, cid);
                }
                else
                {
                    url = string.Format("{0}&cid={1}", context.Request.RawUrl, cid);
                }
            }
            context.RewritePath(url);
        }
        public void Dispose() { }
        public class AppendSIDFilter : Stream
        {
            private Stream Sink { get; set; }
            private long _position;
            private System.Text.StringBuilder oOutput = new StringBuilder();
            public AppendSIDFilter(Stream sink)
            {
                Sink = sink;
            }
            public override bool CanRead
            {
                get { return true; }
            }
            public override bool CanSeek
            {
                get { return true; }
            }
            public override bool CanWrite
            {
                get { return true; }
            }
            public override long Length
            {
                get { return 0; }
            }
            public override long Position
            {
                get { return _position; }
                set { _position = value; }
            }
            public override long Seek(long offset, System.IO.SeekOrigin direction)
            {
                return Sink.Seek(offset, direction);
            }
            public override void SetLength(long length)
            {
                Sink.SetLength(length);
            }
            public override void Close()
            {
                Sink.Close();
            }
            public override void Flush()
            {
                Sink.Flush();
            }
            public override int Read(byte[] buffer, int offset, int count)
            {
                return Sink.Read(buffer, offset, count);
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                if (string.IsNullOrEmpty(HttpContext.Current.Request["cid"]))
                {
                    Sink.Write(buffer, 0, buffer.Length);
                    return;
                }
                string content = System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count);
                Regex regex = new Regex(@"^((https|http|ftp|rtsp|mms)?:\/\/)[^\s]+", RegexOptions.IgnoreCase);
                //Regex action_regex = new Regex(RegexResource.ACTION, RegexOptions.IgnoreCase);
                if (regex.IsMatch(content))
                {
                    content = Regex.Replace(content, @"^((https|http|ftp|rtsp|mms)?:\/\/)[^\s]+", new MatchEvaluator(ReplaceSID), RegexOptions.Compiled | RegexOptions.IgnoreCase);
                }
                //if (action_regex.IsMatch(content))
                //{
                //    content = Regex.Replace(content, RegexResource.ACTION, new MatchEvaluator(ReplaceSID), RegexOptions.Compiled | RegexOptions.IgnoreCase);
                //}
                byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(content);
                Sink.Write(data, 0, data.Length);
            }
            public static string ReplaceSID(Match match)
            {
                if (match.Value.IndexOf("cid=") != -1)
                {
                    return match.Value;
                }
                string result;
                if (match.Value.IndexOf('?') == -1)
                {
                    result = match.Value.Insert(match.Value.Length - 1, "?cid=" + HttpContext.Current.Request["cid"]);
                }
                else
                {
                    result = match.Value.Insert(match.Value.Length - 1, "&cid=" + HttpContext.Current.Request["cid"]);
                }
                return result;
            }
        }
    }
}