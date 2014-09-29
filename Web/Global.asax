<%@ Application Language="C#" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="PetShop.Model" %>
<%@ Import Namespace="System.Web.Mvc" %> 
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    public void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new HandleErrorAttribute());
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        routes.MapRoute("Home",
        "home/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional });
    }

    // Carry over profile property values from an anonymous to an authenticated state 
    void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs e) {
        ProfileCommon anonProfile = Profile.GetProfile(e.AnonymousID);

        // Merge anonymous shopping cart items to the authenticated shopping cart items
        foreach (CartItemInfo cartItem in anonProfile.ShoppingCart.CartItems)
            Profile.ShoppingCart.Add(cartItem);

        // Merge anonymous wishlist items to the authenticated wishlist items
        foreach (CartItemInfo cartItem in anonProfile.WishList.CartItems)
            Profile.WishList.Add(cartItem);

        // Clean up anonymous profile
        ProfileManager.DeleteProfile(e.AnonymousID);
        AnonymousIdentificationModule.ClearAnonymousIdentifier();
        
        // Save profile
        Profile.Save();
    }

    private static string LOG_SOURCE = ConfigurationManager.AppSettings["Event Log Source"];
    
    // If an exception is thrown in the application then log it to an event log
    protected void Application_Error(object sender, EventArgs e) {
        Exception x = Server.GetLastError().GetBaseException();
        EventLog.WriteEntry(LOG_SOURCE, x.ToString(), EventLogEntryType.Error);
    }

    protected void Application_Start(object sender, EventArgs e)
    {
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-2.1.1.js"
            });
    }
</script>

