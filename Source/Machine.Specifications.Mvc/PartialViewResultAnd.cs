namespace Machine.Specifications.Mvc
{
    using System.Web.Mvc;

    public class PartialViewResultAnd
    {
        readonly PartialViewResult viewResult;

        public PartialViewResultAnd(PartialViewResult viewResult)
        {
            this.viewResult = viewResult;
        }

        public PartialViewResult And()
        {
            return this.viewResult;
        }
    }
}