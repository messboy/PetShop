using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace MVCweb
{
    public class Profile : ProfileBase
    {
        public virtual PetShop.BLL.Cart WishList
        {
            get
            {
                return ((PetShop.BLL.Cart)(this.GetPropertyValue("WishList")));
            }
            set
            {
                this.SetPropertyValue("WishList", value);
            }
        }

        public virtual PetShop.BLL.Cart ShoppingCart
        {
            get
            {
                return ((PetShop.BLL.Cart)(this.GetPropertyValue("ShoppingCart")));
            }
            set
            {
                this.SetPropertyValue("ShoppingCart", value);
            }
        }

        public virtual PetShop.Model.AddressInfo AccountInfo
        {
            get
            {
                return ((PetShop.Model.AddressInfo)(this.GetPropertyValue("AccountInfo")));
            }
            set
            {
                this.SetPropertyValue("AccountInfo", value);
            }
        }

        public virtual Profile GetProfile(string username)
        {
            return ((Profile)(ProfileBase.Create(username)));
        }
    }
}