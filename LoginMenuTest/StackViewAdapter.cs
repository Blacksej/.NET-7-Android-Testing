using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMenuTest
{
    public class StackViewAdapter : ListActivity
    {
        string[] items;
        protected override void OnListItemClick(ListView? l, View? v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
        }
    }
}
