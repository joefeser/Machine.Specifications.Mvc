using System.Web.Mvc;

namespace Machine.Specifications.Mvc.Specs.ActionResults
{
    public class TestViewResult : ViewResultBase
    {
        protected override ViewEngineResult FindView(ControllerContext context)
        {
            return null;
        }
    }
}
