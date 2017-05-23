using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ActivityDiary
{
    [Activity(Label = "AddActivity")]
    public class AddActivity : Activity
    {
        EditText et_title, et_date, et_timeFrom, et_timeTo, et_desctription;

        Button btn_add, btn_back;

        DataBase dataBase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LayoutAdd);

            et_title = FindViewById<EditText>(Resource.Id.editTextTitle);
            et_date = FindViewById<EditText>(Resource.Id.editTextDate);
            et_timeFrom = FindViewById<EditText>(Resource.Id.editTextTimeFrom);
            et_timeTo = FindViewById<EditText>(Resource.Id.editTextTimeTo);
            et_desctription = FindViewById<EditText>(Resource.Id.editTextDescription);

            btn_back = FindViewById<Button>(Resource.Id.buttonBack);
            btn_back.Click += Btn_back_Click;

            btn_add = FindViewById<Button>(Resource.Id.buttonAdd);
            btn_add.Click += Btn_add_Click;

            dataBase = new DataBase();
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Act insertAct = new Act()
                {
                    Id = 0,
                    Date = et_date.Text,
                    Description = et_desctription.Text,
                    TimeFrom = et_timeFrom.Text,
                    TimeTo = et_timeTo.Text,
                    Title = et_title.Text
                };

                bool result = dataBase.InsertNew(insertAct);

                if (result == true)
                {
                    Toast.MakeText(this, "Успех. Вернитесь назад", ToastLength.Long).Show();

                    et_date.Text = String.Empty;
                    et_desctription.Text = String.Empty;
                    et_timeFrom.Text = String.Empty;
                    et_timeTo.Text = String.Empty;
                    et_title.Text = String.Empty;
                }
                else
                {
                    Toast.MakeText(this, "Неудача. Попробуйте снова", ToastLength.Long).Show();
                }
            }
            catch
            {
                Toast.MakeText(this, "Неудача. Попробуйте снова", ToastLength.Long).Show();
            }
        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}