using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class LinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public LinkTagHelper (IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }
    }
}
