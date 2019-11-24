namespace House2Invest
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;    
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    [HtmlTargetElement(Attributes="is-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private IDictionary<string, string> _routeValues;

        public ActiveRouteTagHelper(IHttpContextAccessor contextAccessor)
        {
            this._contextAccessor = contextAccessor;
        }

        private void MakeActive(TagHelperOutput output)
        {
            TagHelperAttribute attribute = Enumerable.FirstOrDefault<TagHelperAttribute>(output.Attributes, delegate (TagHelperAttribute a) {
                return a.Name=="class";
            });
            if (attribute == null)
            {
                attribute = new TagHelperAttribute("class", "active");
                output.Attributes.Add(attribute);
            }
            else if ((attribute.Value == null) || (attribute.Value.ToString().IndexOf("active") < 0))
            {
                output.Attributes.SetAttribute("class", (attribute.Value == null) ? "active" : (attribute.Value.ToString() + " active"));
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            //if (this.ShouldBeActive())
            //{
            //    this.MakeActive(output);
            //}
            output.Attributes.RemoveAll("is-active-route");
        }

        //private bool ShouldBeActive()
        //{
        //    bool flag;
        //    string str = string.Empty;
        //    string str2 = string.Empty;
        //    if (ViewContext.RouteData.Values().Item("Controller") != null)
        //    {
        //        str = this.ViewContext.RouteData().Values().Item("Controller").ToString();
        //    }
        //    if (this.ViewContext.RouteData().Values().Item("Action") != null)
        //    {
        //        str2 = this.ViewContext.RouteData().Values().Item("Action").ToString();
        //    }
        //    if (this.Controller != null)
        //    {
        //        if (!string.IsNullOrWhiteSpace(this.Controller) && (this.Controller.ToLower() != str.ToLower()))
        //        {
        //            return false;
        //        }
        //        if (!string.IsNullOrWhiteSpace(this.Action) && (this.Action.ToLower() != str2.ToLower()))
        //        {
        //            return false;
        //        }
        //    }
        //    if (((this.Page != null) && !string.IsNullOrWhiteSpace(this.Page)) && (this.Page.ToLower() != this._contextAccessor.HttpContext().Request().Path().Value().ToLower()))
        //    {
        //        return false;
        //    }
        //    using (IEnumerator<KeyValuePair<string, string>> enumerator = this.RouteValues.GetEnumerator())
        //    {
        //        while (true)
        //        {
        //            if (enumerator.MoveNext())
        //            {
        //                KeyValuePair<string, string> current = enumerator.Current;
        //                if (this.ViewContext.RouteData().Values().ContainsKey(current.Key) && (this.ViewContext.RouteData().Values().Item(current.Key).ToString() == current.Value))
        //                {
        //                    continue;
        //                }
        //                flag = false;
        //            }
        //            else
        //            {
        //                return true;
        //            }
        //            break;
        //        }
        //    }
        //    return flag;
        //}

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix="asp-route-")]
        public IDictionary<string, string> RouteValues
        {
            get
            {
                if (this._routeValues == null)
                {
                    this._routeValues = (IDictionary<string, string>)new Dictionary<string, string>((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase) ;
                }
                return this._routeValues;
            }
            set
            {
                this._routeValues = value;
            }
        }
    }
}

