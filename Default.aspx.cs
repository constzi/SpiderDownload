using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Drawing.Image image = DownloadImageFromUrl("https://ny-image3.etsy.com/000/0/6867067/il_fullxfull.366903859.jpg");
        string rootPath = @"C:\Users\ccc\Desktop"; // add folder name: eg. \Images
        string fileName = System.IO.Path.Combine(rootPath, "test.jpg");
        image.Save(fileName);
    }

    public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
    {
        System.Drawing.Image image = null;
        try
        {
            System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
            webRequest.AllowWriteStreamBuffering = true;
            webRequest.Timeout = 30000;
            System.Net.WebResponse webResponse = webRequest.GetResponse();
            System.IO.Stream stream = webResponse.GetResponseStream();
            image = System.Drawing.Image.FromStream(stream);
            webResponse.Close();
        }
        catch (Exception ex)
        {
            return null;
        }
        return image;
    }
}
