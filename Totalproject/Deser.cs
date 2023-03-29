using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Totalproject
{
    internal class Deser
    {

        public static T Deserializeobject<T>()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(dialog.FileName);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                return default(T);
            }
        }
        
    }
}
