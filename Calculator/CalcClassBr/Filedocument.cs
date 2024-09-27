using System.IO;


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
