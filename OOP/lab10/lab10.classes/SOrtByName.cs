using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace lab10.classes
{
    public class SOrtByName : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Animal a1 = x as Animal;
            Animal a2 = y as Animal;

            if (a1 != null && a2 != null)
            {
                return string.Compare(a1.Name, a2.Name);
            }
            return 0;
        }
    }
}