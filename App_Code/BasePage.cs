using System;
using System.Web;

public class BasePage : System.Web.UI.Page
{
    private void Page_PreRender(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.Title) || this.Title.Equals("Untitled Page", StringComparison.CurrentCultureIgnoreCase))
        {
            throw new Exception("Page title cannot be \"Untitled Page\" or an empty string.");
        }
    }

    public BasePage()
    {
        this.PreRender += Page_PreRender;
        this.PreInit += Page_PreInit;
    }

    private void Page_PreInit(object sender, EventArgs e)
    {
        HttpCookie preferredTheme = Request.Cookies.Get("PreferredTheme"); //get the cookie...
        if (preferredTheme != null) //if the cookie exists...
        {
            string folder = Server.MapPath("~/App_Themes/" + preferredTheme.Value); //get the path of the theme...
            if (System.IO.Directory.Exists(folder)) //if the path of the theme exists...
            {
                Page.Theme = preferredTheme.Value; //set the theme to that of the theme represented by the cookie's value.
            }
        }

    }

}