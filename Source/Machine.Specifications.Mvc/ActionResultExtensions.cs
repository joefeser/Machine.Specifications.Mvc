namespace Machine.Specifications.Mvc
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public static class ActionResultExtensions
    {
        public static ActionResultAnd<ViewResult> ShouldBeAView(this ActionResult actionResult)
        {
            return actionResult.ShouldBeA<ViewResult>();
        }

        public static ActionResultAnd<PartialViewResult> ShouldBeAPartialView(this ActionResult actionResult)
        {
            return actionResult.ShouldBeA<PartialViewResult>();
        }

        public static ActionResultAnd<RedirectToRouteResult> ShouldBeARedirectToRoute(this ActionResult actionResult)
        {
            return actionResult.ShouldBeA<RedirectToRouteResult>();
        }

        public static T Model<T>(this ActionResult actionResult)
        {
            return actionResult.ShouldBeAView().And().ShouldHaveModelOfType<T>().And();
        }

        public static ActionResultAnd<RedirectResult> ShouldBeARedirect(this ActionResult actionResult)
        {
            return actionResult.ShouldBeA<RedirectResult>();
        }

        public static void ShouldRedirectToAction<TController>(this ActionResult actionResult, Expression<Action<TController>> action) where TController : Controller
        {
            // only test the controller name if the controller route value is present (it's not present when redirecting within same controller)
            if (actionResult.ShouldBeARedirectToRoute().And().RouteValues["controller"] != null)
            {            
                actionResult.ShouldBeARedirectToRoute().And().ControllerName().ToLower().ShouldEqual(ControllerExtensions.RoutingName<TController>().ToLower());
            }

            actionResult.ShouldBeARedirectToRoute()
                .And().ActionName().ToLower().ShouldEqual(action.GetMethodBodyName().ToLower());
        }

        public static ActionResultAnd<TActionResult> ShouldBeA<TActionResult>(this ActionResult actionResult)
            where TActionResult : ActionResult
        {
            actionResult.ShouldBeOfType<TActionResult>();
            return new ActionResultAnd<TActionResult>(actionResult as TActionResult);
        }
    }
}