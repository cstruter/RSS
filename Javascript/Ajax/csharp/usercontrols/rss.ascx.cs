using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class usercontrols_rss : System.Web.UI.UserControl
{
    public string Title
    {
        get
        {
            return lblTitle.Text;
        }
        set
        {
            lblTitle.Text = value;
        }
    }

    public string Description
    {
        get
        {
            return lblDescription.Text;
        }
        set
        {
            lblDescription.Text = value;
        }
    }

    public string Link
    {
        get
        {            
            return hlRss.NavigateUrl;
        }
        set
        {
            hlRss.NavigateUrl = value;
        }
    }

    public object DataSource
    {
        set
        {
            dlRSS.DataSource = value;
            dlRSS.DataBind();
        }
    }
      

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
