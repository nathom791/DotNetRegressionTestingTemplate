namespace Utilities
{
    public static class FileManagement
    {
        public static readonly string WorkingDir = Environment.CurrentDirectory;
        public static readonly string ProjectDir = Directory.GetParent(WorkingDir).Parent.Parent.FullName;
        public static readonly string SolutionDir = Directory.GetParent(WorkingDir).Parent.Parent.Parent.FullName;
        public static readonly string OnFailureDir = Path.Combine(ProjectDir + "\\OnFailure").Replace('\\', Path.DirectorySeparatorChar);
        public static readonly string DownloadsDir = Path.Combine(ProjectDir + "\\Downloads").Replace('\\', Path.DirectorySeparatorChar);
        public static readonly string AssetsDir = Path.Combine(ProjectDir + "\\Assets").Replace('\\', Path.DirectorySeparatorChar);

        public static void CleanOnFailureFolder()
        {
            Directory.CreateDirectory(OnFailureDir);
            DirectoryInfo di = new(OnFailureDir);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        public static void CleanDownloadsFolder()
        {
            Directory.CreateDirectory(DownloadsDir);
            DirectoryInfo di = new(DownloadsDir);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        public static async Task WaitForFileToExistAsync(string filePath)
        {
            for (int i = 0; i < 60; i++)
            {
                await Task.Delay(1000);
                if (File.Exists(filePath))
                {
                    break;
                }
            }
        }
    }
}