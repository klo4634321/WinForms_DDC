using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_DDC
{
    public class GlobalFunc
    {
        private static GlobalFunc _Instance;

        public static GlobalFunc Instance
        {
            get { if( _Instance == null)
            {
                _Instance = new GlobalFunc();
            }
            return _Instance; }
                 
        }

        public int BValue = 0;

        public int CValue = 0;




    }

}
