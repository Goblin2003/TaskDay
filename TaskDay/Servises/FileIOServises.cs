using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDay.Models;

namespace TaskDay.Servises
{
    internal class FileIOServises
    {
        private readonly string PATH;

        public FileIOServises(string path)
        {
            PATH = path;
        }
        public BindingList<Taski> LoadDate() 
        {
            var fileExists = File.Exists(PATH);
            if(!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Taski>();
            }
            using (var stream = File.OpenText(PATH))
            {
                var fileText = stream.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Taski>>(fileText);
            }
            
        }
        public void SaveDate(object todoDateList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDateList);
                writer.Write(output);
            }
        }
    }
}
