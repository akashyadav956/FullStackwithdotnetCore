using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetCoreMvc
{
    [HtmlTargetElement("image", TagStructure = TagStructure.WithoutEndTag)]
    public class ImageTagHelper : TagHelper
    {
        public string Url { get; set; }
        public string FallBackUrl { get; set; }
        private static IHttpContextAccessor httpContextAccessor;
        public ImageTagHelper(IHttpContextAccessor httpconAccessor) {
            httpContextAccessor = httpconAccessor;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.TagMode = TagMode.SelfClosing;
            HttpClient client = new HttpClient();
            if (Url.StartsWith("http") || Url.StartsWith("https"))
            {
                var webUrl = new Uri(Url);
                client.BaseAddress = new Uri($"{webUrl.Scheme}:{webUrl.Host}");
                Url = webUrl.LocalPath;
            }
            else
            {
                var baseUrl = httpContextAccessor.HttpContext.Request.GetDisplayUrl();
                client.BaseAddress = new Uri(baseUrl);
            }



            using (HttpResponseMessage response = await client.GetAsync(Url))
            {
                if (response.IsSuccessStatusCode)
                {
                    output.Attributes.SetAttribute("src", Url);
                }
                else
                {
                    output.Attributes.SetAttribute("src", FallBackUrl);
                }
            }


        }

    }
}
