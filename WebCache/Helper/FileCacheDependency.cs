namespace WebCache.Helper
{
    public class FileCacheDependency
    {
        public FileCacheDependency(string filename)
        {
            FileName = filename;
        }

        public string FileName { get; }
    }
}
