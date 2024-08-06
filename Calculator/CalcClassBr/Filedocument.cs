using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcClassBr
{
    public class FileDocumentUploader
    {
        private string _path;
        public FileDocumentUploader(string path)
        {
            _path = path;
        }

        public Stream UploadDocument()
        {
            return File.OpenRead(_path);
        }
    }
}
