using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza.MAUIClient.Services;
public class HttpsClientHandlerService
{
    public HttpMessageHandler GetPlatformMessageHandler()
    {
#if ANDROID
        var handler = new Xamarin.Android.Net.AndroidMessageHandler();
        handler.ServerCertificateCustomValidationCallback = (pMessage, pCert, pChain, pErrors) =>
        {
            if (pCert != null && pCert.Issuer.Equals("CN=localhost"))
                return true;
            return pErrors == System.Net.Security.SslPolicyErrors.None;
        };
        return handler;
#elif IOS
        var handler = new NSUrlSessionHandler
        {
            TrustOverrideForUrl = IsHttpsLocalhost
        };
        return handler;
#else
     throw new PlatformNotSupportedException("Only Android and iOS supported.");
#endif
    }

#if IOS
    public bool IsHttpsLocalhost(NSUrlSessionHandler pSender, string pUrl, Security.SecTrust pTrust)
    {
        if (pUrl.StartsWith("https://localhost"))
            return true;
        return false;
    }
#endif
}
