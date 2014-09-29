using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public partial class HomeController : Controller
{
    protected override void Execute(System.Web.Routing.RequestContext requestContext)
    {
        base.Execute(requestContext);
    }

    public ActionResult Index()
    {
        var r = new ContentResult();
        r.Content = "Hello World";
        return r;
    }
}