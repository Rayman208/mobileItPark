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
    [Activity(Label = "ActivityDiary", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btn_AddAct;
        ListView lv_Acts;

        DataBase dataBase;

        int selectedIndex;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LayoutMain);

            lv_Acts = FindViewById<ListView>(Resource.Id.listViewActs);

            btn_AddAct =FindViewById<Button>(Resource.Id.buttonAddAct);
            btn_AddAct.Click += Btn_AddAct_Click;

            dataBase = new DataBase();
            dataBase.CreateTable();
            
            LoadActs();

            Toast.MakeText(this, "You are ГОМОСЭКСУАЛИСТ, Welcome\nCreated by Alesha", ToastLength.Long).Show();
        }

        private void Btn_AddAct_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddActivity));
            StartActivityForResult(intent, 0);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            LoadActs();
        }

        private void LoadActs()
        {
            List<Act> acts = dataBase.SelectAll();
            List<string> stringActs = ActsToStringList(acts);

            ArrayAdapter<string> lv_ActsAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, stringActs);

            lv_Acts.Adapter = lv_ActsAdapter;

            RegisterForContextMenu(lv_Acts);
        }
        private List<string> ActsToStringList(List<Act> acts)
        {
            List<string> stringList = new List<string>();
            foreach (Act act in acts)
            {
                string currentAct = String.Format("id:{0}\ntitle:{1}\ndate:{2} from:{3} to:{4}\ndescription:{5}",act.Id,act.Title,act.Date,act.TimeFrom,act.TimeTo,act.Description);

                stringList.Add(currentAct);
            }
            return stringList;
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            base.OnCreateContextMenu(menu, v, menuInfo);
            if (v.Id == Resource.Id.listViewActs)
            {
                menu.Add(Menu.None, 0, 0, "Удалить");
            }
            if (v.Id == Resource.Id.listViewActs)
            {
                var info = (AdapterView.AdapterContextMenuInfo)menuInfo;
                selectedIndex = info.Position;
            }
        }
        public override bool OnContextItemSelected(IMenuItem item)
        {
            Act act = dataBase.SelectByIndex(selectedIndex);
            dataBase.Delete(act);

            LoadActs();

            return base.OnContextItemSelected(item);
        }

    }
}

