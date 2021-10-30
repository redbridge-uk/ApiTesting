using System;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace Redbridge.ApiTesting.Framework
{
    public static class HtmlStringExtensions
    {
        public static string ExtractPasswordResetUrlString(this string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            // <a style="border: 1px solid #ffffff;display: inline-block;font-size: 16px;font-weight: bold;line-height: 20px;outline-style: solid;outline-width: 2px;padding: 10px 30px;text-align: center;text-decoration: none !important;transition: all .2s;color: #fff !important;font-family: sans-serif;background-color: #4db6ac;outline-color: #4db6ac;text-shadow: 0 1px 0 #45a49b;width:80%;" href="http://localhost:60000//#/account/0729023ce09d4f0087b27bb0fb1a61af@easilog.com/reset/SfFy1B&amp;UPY=uHn}9pLf:5ZlDuhvAG*QChg%2T}f{Mr[QR}gHRE;^t#S%b0pK+jHNz]vq}BBu3z?WJ4z?zRM^MGvDafL&amp;i^^k[w9iq;n=CJh*YhuL[Hrs@8+U;+H#&amp;V9c"
            var node = document.DocumentNode.Descendants("a").First(a => a.GetAttributeValue("href", null).Contains("password/change"));
            var uritext = node.GetAttributeValue("href", null);
            return uritext;
        }

        public static Uri ExtractPasswordResetUrl(this string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            // <a style="border: 1px solid #ffffff;display: inline-block;font-size: 16px;font-weight: bold;line-height: 20px;outline-style: solid;outline-width: 2px;padding: 10px 30px;text-align: center;text-decoration: none !important;transition: all .2s;color: #fff !important;font-family: sans-serif;background-color: #4db6ac;outline-color: #4db6ac;text-shadow: 0 1px 0 #45a49b;width:80%;" href="http://localhost:60000//#/account/0729023ce09d4f0087b27bb0fb1a61af@easilog.com/reset/SfFy1B&amp;UPY=uHn}9pLf:5ZlDuhvAG*QChg%2T}f{Mr[QR}gHRE;^t#S%b0pK+jHNz]vq}BBu3z?WJ4z?zRM^MGvDafL&amp;i^^k[w9iq;n=CJh*YhuL[Hrs@8+U;+H#&amp;V9c"
            var node = document.DocumentNode.Descendants("a").First(a => a.GetAttributeValue("href", null).Contains("password/change"));
            var uritext = node.GetAttributeValue("href", null);
            return new Uri(uritext);
        }

        public static Uri ExtractEmailVerificationCodeUrl(this string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            // <a style="border: 1px solid #ffffff;display: inline-block;font-size: 16px;font-weight: bold;line-height: 20px;outline-style: solid;outline-width: 2px;padding: 10px 30px;text-align: center;text-decoration: none !important;transition: all .2s;color: #fff !important;font-family: sans-serif;background-color: #4db6ac;outline-color: #4db6ac;text-shadow: 0 1px 0 #45a49b;width:80%;" href="http://localhost:60000//#/account/0729023ce09d4f0087b27bb0fb1a61af@easilog.com/reset/SfFy1B&amp;UPY=uHn}9pLf:5ZlDuhvAG*QChg%2T}f{Mr[QR}gHRE;^t#S%b0pK+jHNz]vq}BBu3z?WJ4z?zRM^MGvDafL&amp;i^^k[w9iq;n=CJh*YhuL[Hrs@8+U;+H#&amp;V9c"
            var node = document.DocumentNode.Descendants("a").First(a => a.GetAttributeValue("href", null).Contains("verificationCode"));
            var uritext = node.GetAttributeValue("href", null);
            return new Uri(uritext);
        }

        public static string ExtractVerificationCode (this Uri uri)
        {
            var queryParts = HttpUtility.ParseQueryString(uri.Query);
            var code = queryParts["verificationCode"];
            return code;
        }

        public static string ExtractPasswordResetToken(this Uri uri)
        {
            var fragment = uri.Fragment;
            const string reset = "code=";
            string resetToken;

            if (string.IsNullOrEmpty(fragment))
            {
                resetToken = HttpUtility.ParseQueryString(uri.Query)?.GetValues("code")?[0];
            }
            else
                resetToken = fragment.Substring(fragment.IndexOf(reset, StringComparison.Ordinal) + reset.Length);

            return resetToken;
        }
    }
}
