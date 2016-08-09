namespace Machine.Specifications.Mvc
{
    using System.Web.Mvc;

    public static class ViewResultBaseExtensions
    {
        public static ActionResultAnd<TViewResult> ShouldUseView<TViewResult>(this TViewResult viewResult, string viewName)
            where TViewResult : ViewResultBase
        {
            viewResult.ViewName.ShouldEqual(viewName);
            return new ActionResultAnd<TViewResult>(viewResult);
        }

        public static ActionResultAnd<TViewResult> ShouldUseDefaultView<TViewResult>(this TViewResult viewResult)
            where TViewResult : ViewResultBase
        {
            viewResult.ViewName.ShouldBeEmpty();
            return new ActionResultAnd<TViewResult>(viewResult);
        }

        public static ModelTypeAnd<T> ShouldHaveModelOfType<T>(this ViewResultBase viewResult)
        {
            viewResult.ViewData.Model.ShouldBeAssignableTo<T>();
            return new ModelTypeAnd<T>((T) viewResult.ViewData.Model);
        }

        public static ActionResultAnd<TViewResult> ShouldNotHaveAModel<TViewResult>(this TViewResult viewResult)
            where TViewResult : ViewResultBase
        {
            viewResult.Model.ShouldBeNull();
            return new ActionResultAnd<TViewResult>(viewResult);
        }
    }
}