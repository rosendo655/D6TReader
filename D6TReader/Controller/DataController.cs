using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D6TReader.Controller
{
    public class DataController
    {
        public static Stream SaveFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".dat";
            var dialog_res = dialog.ShowDialog();
            if(dialog_res == DialogResult.OK)
            {
                return dialog.OpenFile();
            }
            return null;
        }

        public static (Stream,string) OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".dat";
            var dialog_res = dialog.ShowDialog();
            if(dialog_res == DialogResult.OK)
            {
                return (dialog.OpenFile(), dialog.FileName);
            }   
            return default;
        }
    }
}
