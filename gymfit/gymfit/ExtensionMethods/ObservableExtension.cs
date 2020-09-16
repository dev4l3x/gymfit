using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GymFit.ExtensionMethods
{
    public static class ObservableExtension
    {

        public static List<List<T>> ToListAll<T>(this ObservableCollection<ObservableCollection<T>> oc)
        {
            var toret = new List<List<T>>();
            foreach(var innerList in oc)
            {
                toret.Add(innerList.ToList());
            }
            return toret;
        }

    }
}
