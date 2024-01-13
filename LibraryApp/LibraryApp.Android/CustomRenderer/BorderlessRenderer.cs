
using Android.Content.Res;
using LibraryApp.Droid;
using LibraryApp.Droid.CustomRenderer;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ResolutionGroupName("PlainEntryGroup")]
[assembly: ExportEffect(typeof(BorderlessRenderer), "PlainEntryEffect")]
namespace LibraryApp.Droid.CustomRenderer
{
	public class BorderlessRenderer: PlatformEffect
	{
		public BorderlessRenderer()
		{

		}
        protected override void OnAttached()
        {
            try
            {
                if (Control != null)
                {
                    Android.Graphics.Color entryLineColor = Android.Graphics.Color.Transparent;
                    Control.BackgroundTintList = ColorStateList.ValueOf(entryLineColor);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error... Unable to set property on attached control", ex.Message);
            }
        }
        protected override void OnDetached()
        {
        }
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
        }
    }
}
