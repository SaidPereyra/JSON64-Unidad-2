using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Javax.Net.Ssl;


namespace JsonBase64.Droid.Helpers
{
    public class BypassHostnameVerifier : Java.Lang.Object, IHostnameVerifier
    {

        public bool Verify(string hostname, ISSLSession session)
        {
            return true;
        }
    }
}