using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Web.Handlers;
using System.IO;

using System.Data;

using System.Net;
using System.Net.WebSockets;
using System.Text;

using HtmlAgilityPack;

namespace ReadRSSPOC
{
    public partial class Review : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        // https://rss.app/
        // Amazon : https://rss.app/feeds/FSoukEdumd94HkGZ.xml
        // Ebay : https://rss.app/feeds/kcEEj5iVMFraIF5k.xml

        private DataTable ParseRssFile()
        {
            XmlDocument rssXmlDoc = new XmlDocument();
            //HttpWebRequest rssFeed = (HttpWebRequest)WebRequest.Create("https://rss.app/feeds/kcEEj5iVMFraIF5k.xml");
            WebClient rssFeed = new WebClient();
            rssFeed.UseDefaultCredentials = true;
            rssFeed.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            //rssXmlDoc.LoadXml("https://rss.app/feeds/kcEEj5iVMFraIF5k.xml"); // throwing error
            rssXmlDoc.Load("https://rss.app/feeds/kcEEj5iVMFraIF5k.xml");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");



            //Prepare Datatable and Add All Columns Here
            DataTable dt = new DataTable();
            DataRow row;
            DataColumn dc = new DataColumn();
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "title";
            dc.ReadOnly = false;
            dc.Unique = false;
            dc.AutoIncrement = false;
            dt.Columns.Add(dc);


            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "link";
            dc.ReadOnly = false;
            dc.Unique = false;
            dc.AutoIncrement = false;
            dt.Columns.Add(dc);


            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "description";
            dc.ReadOnly = false;
            dc.Unique = false;
            dc.AutoIncrement = false;
            dt.Columns.Add(dc);


            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "Image";
            dc.ReadOnly = false;
            dc.Unique = false;
            dc.AutoIncrement = false;
            dt.Columns.Add(dc);


            //dc = new DataColumn();
            //dc.DataType = System.Type.GetType("System.String");
            //dc.ColumnName = "enclosure";
            //dc.ReadOnly = false;
            //dc.Unique = false;
            //dc.AutoIncrement = false;
            //dt.Columns.Add(dc);

            HtmlDocument doc = new HtmlDocument();
            string strDescription = string.Empty;

            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                //rssSubNode = rssNode.SelectSingleNode("guid");
                //string guid = rssSubNode != null ? rssSubNode.InnerText : "";

                //rssSubNode = rssNode.SelectSingleNode("enclosure");
                //string enclosure = rssSubNode != null ? rssSubNode.InnerText : "";

                //Add new row and assign values to columns, no need to add columns again and again in loop which will throw exception
                row = dt.NewRow();
                //Map all the values in the columns
                row["title"] = title;
                row["link"] = link;
                //row["description"] = description;
                //row["guid"] = guid;
                //row["enclosure"] = enclosure;


                // Get the index of where the value of src starts.
                int start = description.IndexOf("<img src=\"") + 10;
                // Get the substring that starts at start, and goes up to first \".
                string src = description.Substring(start, description.IndexOf("\"", start) - start);

                doc.LoadHtml(description);
                strDescription = doc.DocumentNode.InnerText.ToString();

                strDescription = strDescription.TrimStart().TrimEnd();

                row["description"] = strDescription;
                row["Image"] = src;
                //At the end just add that row in datatable
                dt.Rows.Add(row);                
            }

            return dt;
           
        }

        public void BindData()
        {
            grdFeed.DataSource = ParseRssFile();
            grdFeed.DataBind();
        }


        protected void grdFeed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grdFeed.PageIndex = e.NewPageIndex;
            BindData();

        }
    }
}


