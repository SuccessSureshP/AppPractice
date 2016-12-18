using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_SampleApp.Model
{
    public class FileDirectory
    {
        public string Name { get; set; }
        public FileDirectory Parent { get; set; }

        public List<FileDirectory> SubDirectories { get; set; }
    }
}
