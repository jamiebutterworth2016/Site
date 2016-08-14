using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_Frontend : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string selectedTheme = Page.Theme; //e.g. "DarkGrey" or "Monochrome"...
            HttpCookie preferredTheme = Request.Cookies.Get("PreferredTheme"); //get the cookie...

            if (preferredTheme != null) //if the cookie exists...
            {
                selectedTheme = preferredTheme.Value; //make the Page.Theme the same theme that the cookie contains...
            }
            if (!string.IsNullOrEmpty(selectedTheme)) //if the theme exists...
            {
                ListItem item = ThemeList.Items.FindByValue(selectedTheme); //if the ddl contains "DarkGrey" or "Monochrome"...
                if (item != null)
                {
                    item.Selected = true; //whatever the theme is, select that theme in the ddl.
                }
            }
        }

        switch (Page.Theme.ToLower()) //Get the page's theme and convert it to a lower case string...
        {
            case "darkgrey": //If the theme is darkgrey, make the menu invisible.
                Menu1.Visible = false;
                TreeView1.Visible = true;
                break;
            default: //If the theme is not darkgrey, make the tree view invisible. Default is like saying "else".
                Menu1.Visible = true;
                TreeView1.Visible = false;
                break;
        }
    }

    protected void ThemeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie preferredTheme = new HttpCookie("PreferredTheme"); //create cookie containing theme name...
        preferredTheme.Expires = DateTime.Now.AddMonths(3);
        preferredTheme.Value = ThemeList.SelectedValue;
        Response.Cookies.Add(preferredTheme);
        Response.Redirect(Request.Url.ToString());
    }
}
