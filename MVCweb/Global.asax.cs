using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Profile;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using PetShop.Model;

namespace MVCweb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 應用程式啟動時執行的程式碼
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs e)
        {
            Profile Profile = new Profile();
            Profile anonProfile = Profile.GetProfile(e.AnonymousID);

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
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception x = Server.GetLastError().GetBaseException();
            EventLog.WriteEntry(LOG_SOURCE, x.ToString(), EventLogEntryType.Error);
        }
    }
}