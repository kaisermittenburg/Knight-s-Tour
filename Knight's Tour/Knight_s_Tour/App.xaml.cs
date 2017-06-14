using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Knight_s_Tour
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new Knight_s_Tour.MainPage();
		}

		protected override void OnStart ()
		{
            Console.WriteLine("Hello World");
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
