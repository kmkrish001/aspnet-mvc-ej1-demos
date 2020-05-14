#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using MVCSampleBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSampleBrowser.Controllers
{
    public partial class RibbonController : Controller
    {
        //
        // GET: /RTL/
        List<FontFamily> fontFamilyrtl = new List<FontFamily>();
        List<FontPoint> fontPointrtl = new List<FontPoint>();
        public ActionResult RTL()
        {
            fontFamilyrtl.Add(new FontFamily { text = "Segoe UI" });
            fontFamilyrtl.Add(new FontFamily { text = "Arial" });
            fontFamilyrtl.Add(new FontFamily { text = "Times New Roman" });
            fontFamilyrtl.Add(new FontFamily { text = "Tahoma" });
            fontFamilyrtl.Add(new FontFamily { text = "Helvetica" });
            ViewBag.datasource = fontFamilyrtl;
            fontPointrtl.Add(new FontPoint { text = "1pt" });
            fontPointrtl.Add(new FontPoint { text = "2pt" });
            fontPointrtl.Add(new FontPoint { text = "3pt" });
            fontPointrtl.Add(new FontPoint { text = "4pt" });
            fontPointrtl.Add(new FontPoint { text = "5pt" });
            ViewBag.datasource1 = fontPointrtl;
            return View();
        }

    }
}