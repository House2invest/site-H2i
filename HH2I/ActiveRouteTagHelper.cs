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
            TagHelperAttribute attribute = Enumerable.FirstOrDefault<TagHelperAttribute>(output.get_Attributes(), delegate (TagHelperAttribute a) {
                return a.get_Name() == "class";
            });
            if (attribute == null)
            {
                attribute = new TagHelperAttribute("class", "active");
                output.get_Attributes().Add(attribute);
            }
            else if ((attribute.get_Value() == null) || (attribute.get_Value().ToString().IndexOf("active") < 0))
            {
                output.get_Attributes().SetAttribute("class", (attribute.get_Value() == null) ? "active" : (attribute.get_Value().ToString() + " active"));
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if (this.ShouldBeActive())
            {
                this.MakeActive(output);
            }
            output.get_Attributes().RemoveAll("is-active-route");
        }

        private bool ShouldBeActive()
        {
            bool flag;
            string str = string.Empty;
            string str2 = string.Empty;
            if (this.ViewContext.get_RouteData().get_Values().get_Item("Controller") != null)
            {
                str = this.ViewContext.get_RouteData().get_Values().get_Item("Controller").ToString();
            }
            if (this.ViewContext.get_RouteData().get_Values().get_Item("Action") != null)
            {
                str2 = this.ViewContext.get_RouteData().get_Values().get_Item("Action").ToString();
            }
            if (this.Controller != null)
            {
                if (!string.IsNullOrWhiteSpace(this.Controller) && (this.Controller.ToLower() != str.ToLower()))
                {
                    return false;
                }
                if (!string.IsNullOrWhiteSpace(this.Action) && (this.Action.ToLower() != str2.ToLower()))
                {
                    return false;
                }
            }
            if (((this.Page != null) && !string.IsNullOrWhiteSpace(this.Page)) && (this.Page.ToLower() != this._contextAccessor.get_HttpContext().get_Request().get_Path().get_Value().ToLower()))
            {
                return false;
            }
            using (IEnumerator<KeyValuePair<string, string>> enumerator = this.RouteValues.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        KeyValuePair<string, string> current = enumerator.Current;
                        if (this.ViewContext.get_RouteData().get_Values().ContainsKey(current.Key) && (this.ViewContext.get_RouteData().get_Values().get_Item(current.Key).ToString() == current.Value))
                        {
                            continue;
                        }
                        flag = false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                }
            }
            return flag;
        }

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix="asp-route-")]
        public IDictionary<string, string> RouteValues
        {
            get
            {
                if (this._routeValues == null)
                {
                    this._routeValues = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.get_OrdinalIgnoreCase());
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

