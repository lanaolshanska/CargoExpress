using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Delivery.Website.Helpers
{
    public static class PartialHelper
    {
        public static MvcHtmlString PartialFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string partialViewName)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            object model = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model;
            var viewData = new ViewDataDictionary(helper.ViewData)
            {
                TemplateInfo = new TemplateInfo
                {
                    HtmlFieldPrefix = string.IsNullOrEmpty(helper.ViewData.TemplateInfo.HtmlFieldPrefix) ?
                  name : $"{helper.ViewData.TemplateInfo.HtmlFieldPrefix}.{name}"
                }
            };
            return helper.Partial(partialViewName, model, viewData);
        }
    }
}