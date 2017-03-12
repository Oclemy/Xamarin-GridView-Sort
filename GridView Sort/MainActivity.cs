using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace GridView_Sort
{
    [Activity(Label = "GridView Sort", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //VIEWS
        private GridView gv;
        private Button sortBtn;

        
        //DATA
        private readonly string[] spacecrafts = { "Kepler", "Casini", "Voyager", "New Horizon", "James Web", "Apollo 15", "Enterprise", "WMAP", "Spitzer", "Galileo" };
        private bool ascending = false;

        //CALLED WHEN ACTIVITY IS CREATED
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
             this.InitializeViews();
             this.SortData(ascending);

             sortBtn.Click += sortBtn_Click;

        }

        //SORT BUTTON CLICKED
        void sortBtn_Click(object sender, EventArgs e)
        {
            SortData(ascending);
            this.ascending = !ascending;
        }

        //INITIALIZE VIEWS
        private void InitializeViews()
        {
            gv = FindViewById<GridView>(Resource.Id.gv);
            sortBtn = FindViewById<Button>(Resource.Id.sortBtn);
        }

        //POPULATE GRIDVIEW
        private void Populate()
        {
            gv.Adapter=new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1,spacecrafts);
        }

        /*
         * SORT
         */
        private void SortData(bool asc)
        {
            //SORT ARRAY ASCENDING AND DESCENDING
            if (asc)
            {
                Array.Sort(spacecrafts);
            }
            else
            {
                Array.Reverse(spacecrafts);
            }

            //CLEAR AND POPULATE LISTBOX
            Populate();

        }
    }

}

