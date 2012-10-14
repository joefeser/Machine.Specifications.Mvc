using System.Web.Mvc;

namespace Machine.Specifications.Mvc
{
    public class ActionResultAnd<TActionResult>
        where TActionResult : ActionResult
    {
        readonly TActionResult actionResult;

        public ActionResultAnd(TActionResult actionResult)
        {
            this.actionResult = actionResult;
        }

        public TActionResult And()
        {
            return actionResult;
        }
    }
}
