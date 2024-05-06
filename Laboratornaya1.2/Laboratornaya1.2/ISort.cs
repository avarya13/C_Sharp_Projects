using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya1._2
{
    interface ISort
    {
        //void Sortmarks(ref float[] marks);
        
        void OutputSortedDB(ref Student[] students, float[] marks);
    }
}
