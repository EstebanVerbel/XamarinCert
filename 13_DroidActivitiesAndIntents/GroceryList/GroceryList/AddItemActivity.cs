using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "Add Item")]			
	public class AddItemActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.AddItem);

			FindViewById<Button>(Resource.Id.saveButton  ).Click += OnSaveClick;
			FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
		}

		void OnSaveClick(object sender, EventArgs e)
		{
			string name  = FindViewById<EditText>(Resource.Id.nameInput).Text;
			int    count = int.Parse(FindViewById<EditText>(Resource.Id.countInput).Text);

            var intent = new Intent();
            intent.PutExtra("ItemName", name);
            intent.PutExtra("ItemCount", count);

            // this sets the result, which means we can finish the activity without any problem
            SetResult(Result.Ok, intent);

            Finish();
		}

		void OnCancelClick(object sender, EventArgs e)
		{
            // this finishes the current activity. Acts like a Cancel button
            Finish();
		}
	}
}