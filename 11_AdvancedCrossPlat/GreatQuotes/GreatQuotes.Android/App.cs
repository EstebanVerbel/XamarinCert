using Android.App;
using Android.Runtime;
using GreatQuotes.Data;
using System;

namespace GreatQuotes
{
    [Application(Icon="@drawable/icon", Label="@string/app_name")]
	public class App : Application
	{
		
		public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();

            QuoteLoaderFactory.Create = () => new QuoteLoader();
		}
        
		public static void Save()
		{
            QuoteManager.Instance.Save();
		}
	}
}

