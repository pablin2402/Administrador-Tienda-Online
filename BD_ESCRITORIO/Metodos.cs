using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_ESCRITORIO
{
    class Metodos
    {

        public static void fillcb(ComboBox combo_box, string _string) {

            DataTable dt = BBDDComun.GetMysqltable(_string);
            foreach (DataRow row in dt.Rows ) {
                string wine = string.Format("{0}",row.ItemArray[0]);
                combo_box.Items.Add(wine);  

            }
        }
    }
}
