#region Copyright Syncfusion Inc. 2001-2021
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Syncfusion.Presentation;
using System.Drawing;
using System.IO;


namespace MVCSampleBrowser.Controllers
{
    public partial class PresentationController : Controller
    {
        //
        // GET: /SlideTransition/

        public ActionResult SlideTransition()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SlideTransition(string Browser)
        {
           string filename = "Transition.pptx";
            IPresentation presentation = Presentation.Open(ResolveApplicationDataPath(filename));
            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].

            //Method call to create slides
            CreateTransition(presentation);

            //Saves the presentation
            return new PresentationResult(presentation, "TransitionSample.pptx", HttpContext.ApplicationInstance.Response);


        }

        #region Slide1
        private void CreateTransition(IPresentation presentation)
        {
            //Get the first slide from the presentation
            ISlide slide1 = presentation.Slides[0];

            // Add the 'Wheel' transition effect to the first slide
            slide1.SlideTransition.TransitionEffect = Syncfusion.Presentation.SlideTransition.TransitionEffect.Wheel;
            
            // Get the second slide from the presentation
            ISlide slide2 = presentation.Slides[1];

            // Add the 'Checkerboard' transition effect to the second slide
            slide2.SlideTransition.TransitionEffect = Syncfusion.Presentation.SlideTransition.TransitionEffect.Checkerboard;

            // Add the subtype to the transition effect
            slide2.SlideTransition.TransitionEffectOption = Syncfusion.Presentation.SlideTransition.TransitionEffectOption.Across;

            // Apply the value to transition mouse on click parameter
            slide2.SlideTransition.TriggerOnClick = true;

            // Get the third slide from the presentation
            ISlide slide3 = presentation.Slides[2];

            // Add the 'Orbit' transition effect for slide
            slide3.SlideTransition.TransitionEffect = Syncfusion.Presentation.SlideTransition.TransitionEffect.Orbit;

            // Add the speed for transition
            slide3.SlideTransition.Speed = Syncfusion.Presentation.SlideTransition.TransitionSpeed.Fast;

            // Get the fourth slide from the presentation
            ISlide slide4 = presentation.Slides[3];

            // Add the 'Uncover' transition effect to the slide
            slide4.SlideTransition.TransitionEffect = Syncfusion.Presentation.SlideTransition.TransitionEffect.Uncover;

            // Apply the value to advance on time for slide
            slide4.SlideTransition.TriggerOnTimeDelay = true;

            // Assign the advance on time value
            slide4.SlideTransition.TimeDelay = 5;

            // Get the fifth slide from the presentation
            ISlide slide5 = presentation.Slides[4];

            // Add the 'PageCurlDouble' transition effect to the slide
            slide5.SlideTransition.TransitionEffect = Syncfusion.Presentation.SlideTransition.TransitionEffect.PageCurlDouble;

            // Add the duration value for the transition effect
            slide5.SlideTransition.Duration = 5;
        }
#endregion
    }
}
