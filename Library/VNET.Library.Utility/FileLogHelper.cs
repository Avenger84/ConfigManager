using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VNET.Library.Utility
{
    public class FileLogHelper
    {
        public static void LogFunction(string functionName, string message, string logPath)
        {
            WriteFunctionText(functionName, message, logPath);
        }

        private static System.Threading.ReaderWriterLockSlim cacheLock = new System.Threading.ReaderWriterLockSlim();

        public static void WriteFunctionText(string functionName, string message, string logPath)
        {
            if (string.IsNullOrWhiteSpace(logPath))
            {
                return;
            }

            string logDirectoryToday = string.Format("{0}{1}", logPath, DateTime.Now.ToString("yyyy.MM.dd"));
            string logFilePathApplication = string.Format(@"{0}\{1}.txt", logDirectoryToday, functionName);

            DirectoryIsNotExistCreateIt(logDirectoryToday);
            FileIsNotExistCreateIt(logFilePathApplication);
            AddMessageToTheFile(logFilePathApplication, message);
        }

        public static void WriteFunctionTextWithoutDayFolderReturnIfFileExists(string functionName, string message, string logPath)
        {
            if (string.IsNullOrWhiteSpace(logPath))
            {
                return;
            }

            //string logDirectoryToday = string.Format("{0}{1}", logPath, DateTime.Now.ToString("yyyy.MM.dd"));

            if (logPath.EndsWith(@"\"))
            {
                logPath = logPath.Remove(logPath.Length - 1);
            }

            string logFilePathApplication = string.Format(@"{0}\{1}.txt", logPath, functionName);

            if (File.Exists(logFilePathApplication))
            {
                return;
            }

            DirectoryIsNotExistCreateIt(logPath);
            FileIsNotExistCreateIt(logFilePathApplication);
            AddMessageToTheFile(logFilePathApplication, message);
        }

        private static void DirectoryIsNotExistCreateIt(string path)
        {
            cacheLock.EnterUpgradeableReadLock();

            try
            {
                if (!Directory.Exists(path))
                {
                    cacheLock.EnterWriteLock();

                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    finally
                    {
                        cacheLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                cacheLock.ExitUpgradeableReadLock();
            }
        }

        private static void FileIsNotExistCreateIt(string path)
        {
            cacheLock.EnterUpgradeableReadLock();

            try
            {
                if (!File.Exists(path))
                {
                    cacheLock.EnterWriteLock();

                    try
                    {
                        File.Create(path).Dispose();
                    }
                    finally
                    {
                        cacheLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                cacheLock.ExitUpgradeableReadLock();
            }
        }

        private static void AddMessageToTheFile(string path, string message)
        {
            cacheLock.EnterWriteLock();

            try
            {
                using (FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        writer.AutoFlush = true;
                        writer.Write(message + Environment.NewLine);
                    }
                }
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public static void WriteToFile(string data, string filePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(data);
            }
        }

        public static void WriteToFile(string data, string filePath, Encoding encoding)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, false, encoding))
            {
                streamWriter.WriteLine(data);
            }
        }

        public static string ReadFromFile(string filePath)
        {
            string data = string.Empty;

            using (StreamReader sr = new StreamReader(filePath))
            {
                data = sr.ReadToEnd();
            }

            return data;
        }

    }
}