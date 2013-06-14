using System;
using System.IO;
using System.Reflection;

namespace Reporter
{
    public static class FileUtility
    {
        public static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public static bool FileContentsAreEqual(FileInfo fileInfo1, FileInfo fileInfo2)
        {
            bool result;

            if (fileInfo1.Length != fileInfo2.Length)
            {
                result = false;
            }
            else
            {
                using (var file1 = fileInfo1.OpenRead())
                {
                    using (var file2 = fileInfo2.OpenRead())
                    {
                        result = StreamContentsAreEqual(file1, file2);
                    }
                }
            }

            return result;
        }

        internal static bool StreamContentsAreEqual(Stream stream1, Stream stream2)
        {
            const int bufferSize = 2048 * 2;
            var buffer1 = new byte[bufferSize];
            var buffer2 = new byte[bufferSize];

            while (true)
            {
                int count1 = stream1.Read(buffer1, 0, bufferSize);
                int count2 = stream2.Read(buffer2, 0, bufferSize);

                if (count1 != count2)
                {
                    return false;
                }

                if (count1 == 0)
                {
                    return true;
                }

                int iterations = (int)Math.Ceiling((double)count1 / sizeof(Int64));
                for (int i = 0; i < iterations; i++)
                {
                    if (BitConverter.ToInt64(buffer1, i * sizeof(Int64)) != BitConverter.ToInt64(buffer2, i * sizeof(Int64)))
                    {
                        return false;
                    }
                }
            }
        }

        public static void SyncReportsFromServer(string serverReportFolder, string localReportFolder)
        {
            if (Directory.Exists(serverReportFolder) && Directory.Exists(localReportFolder))
            {
                DirectoryInfo serverDirInfo = new DirectoryInfo(serverReportFolder);
                FileInfo[] serverFiles = serverDirInfo.GetFiles("*.rpt");

                DirectoryInfo localDirInfo = new DirectoryInfo(localReportFolder);
                FileInfo[] localFiles = localDirInfo.GetFiles("*.rpt");

                foreach (FileInfo serverFile in serverFiles)
                {
                    foreach (FileInfo localFile in localFiles)
                    {
                        CompareFiles(serverFile, localFile);
                    }
                }
            }
        }

        public static void CompareServerFileToLocalFile(string serverReportPath, string localReportPath)
        {
            FileInfo serverFile = new FileInfo(serverReportPath);
            FileInfo localFile = new FileInfo(localReportPath);

            CompareFiles(serverFile, localFile);
        }

        public static void CompareLocalFileToServerFile(string localReportPath, string serverReportPath)
        {
            FileInfo serverFile = new FileInfo(serverReportPath);
            FileInfo localFile = new FileInfo(localReportPath);

            CompareFiles(localFile, serverFile);
        }

        internal static void CompareFiles(FileInfo file1, FileInfo file2)
        {
            if (file1.Name == file2.Name)
            {
                if (!FileUtility.FileContentsAreEqual(file1, file2))
                {
                    File.Copy(file1.FullName, file2.FullName);
                }
            }
        }

        internal static void CopyLocalFileToServer(string localReportPath, string serverReportPath)
        {
            File.Copy(localReportPath, serverReportPath);
        }
    }
}
