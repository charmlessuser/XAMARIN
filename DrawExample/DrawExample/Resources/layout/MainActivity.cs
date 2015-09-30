using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace scrollbartest
{
	[Activity (Label = "scrollbartest", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		string[] intensity_arr;
		string[] hexcijfers;
		string[] hexcijfers2;
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
			SeekBar intensity = FindViewById<SeekBar> (Resource.Id.seekBar1);
			TextView waarde = FindViewById<TextView> (Resource.Id.textView1);
			waarde.Text = string.Format ("The value of the intensity is: ") + intensity_arr [0];
			TextView test = FindViewById<TextView> (Resource.Id.textView2);
			test.Text = "";




			/*for (int z = 0; z < 256; z++) {
				test.Text += intensity_arr [z];	
				test.Text += "  ";
			}*/

			intensity.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser) {
					waarde.Text = string.Format ("The value of the intensity is {0}", intensity_arr[e.Progress]);

				}

			};
			
		}

	}}



