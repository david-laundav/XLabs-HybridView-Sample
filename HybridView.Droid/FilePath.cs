namespace HybridView.Droid
{
    public class FilePath : IFilePath
    {
        public string GetFilePath()
        {
            return "file:///android_asset";
        }
    }
}