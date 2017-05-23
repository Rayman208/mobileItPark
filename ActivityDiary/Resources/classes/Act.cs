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

using SQLite;

namespace ActivityDiary
{
    class Act
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Title { set; get; }
        public string Date { set; get; }
        public string TimeFrom { set; get; }
        public string TimeTo { set; get; }
        public string Description { set; get; }
    }
}