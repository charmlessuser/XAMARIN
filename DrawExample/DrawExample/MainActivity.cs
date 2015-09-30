using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace DrawExample
{
	[Activity (Label = "DrawExample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		string intensiteit;
		string[] intensity_arr;
		string[] hexcijfers;
		string[] hexcijfers2;
		Bitmap b = null;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			intensity_arr = new string[256];
			hexcijfers = new string[]{"0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F"};


			int j = 0;
			int k = 0;

			for(int i = 0; i < 256;i++)
			{

				intensity_arr [i] += hexcijfers [j];
				intensity_arr [i] += hexcijfers [k];
				k++;
				if (k == 16) {
					k = 0;
					j++;
				}

			}

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			Utils.Util.SetDisplayMetrics (Resources.DisplayMetrics);
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.btn_draw);
			ImageView iv = FindViewById<ImageView> (Resource.Id.imageView_output);
			SeekBar intensity = FindViewById<SeekBar> (Resource.Id.seekBar1);
			int width = Utils.Util.DetectScreenSize ().Width;
			int height = Utils.Util.DetectScreenSize ().Height;


			intensity.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser) {
					intensiteit = intensity_arr [e.Progress];
					if (b != null) {
						iv.SetImageBitmap (null);
					}
					b = DrawImages.GetImage (width, height,intensiteit);
					iv.SetImageBitmap (b);
					b.Dispose ();
		
					//waarde.Text = string.Format ("The value of the intensity is {0}", intensity_arr[e.Progress]);
				}
			};
				button.Click += delegate {
				intensiteit = intensity_arr[intensity.Progress];
					if (b != null) {
						iv.SetImageBitmap (null);
					}
					b = DrawImages.GetImage (width, height,intensiteit);
					iv.SetImageBitmap (b);
					b.Dispose ();

				};



	}
}
}



