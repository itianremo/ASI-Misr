using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;


namespace AccountabilityNotePad
{
    class FileSearchpattern
    {
        public FileSearchpattern()
        { 
        
        }
        #region GetFiles (string Path)
        /// <summary>
        /// Gets all the files in the given folder path and all its subdirectories
        /// </summary>
        public static string[] GetFiles(string path)
        {
            ArrayList files = new ArrayList();
            getFiles(path, ref files);

            return (string[])files.ToArray(typeof(string));
        }
        private static void getFiles(string path, ref ArrayList files)
        {
            try
            {
                string[] folders = Directory.GetDirectories(path);
                for (int i = 0; i < folders.Length; i++)
                    getFiles(folders[i], ref files);
                string[] curFiles = Directory.GetFiles(path);
                files.AddRange(curFiles);
            }
            catch
            { }
        }
        #endregion

        #region GetFiles (string path, string[] searchPatterns, bool includeSubFolders) +1 overload
        /// <summary>
        /// Gets all the files in the given folder path and all its subdirectories.
        /// </summary>
        /// <param name="searchPatterns">search patterns (ie, "*.exe")</param>
        public static string[] GetFiles(string path, string[] searchPatterns, bool includeSubFolders)
        {
            ArrayList files = new ArrayList();
            if (includeSubFolders)
            {
                getFiles(path, searchPatterns, ref files);
            }
            else
            {
                try
                {
                    for (int i = 0; i < searchPatterns.Length; i++)
                    {
                        string[] curFiles = Directory.GetFiles(path, searchPatterns[i]);
                        files.AddRange(curFiles);
                    }
                }
                catch
                { }
            }
            return (string[])files.ToArray(typeof(string));
        }


        /// <summary>
        /// Gets all the files in the given folder path and all its subdirectories.
        /// </summary>
        /// <param name="searchPattern">A series of valid search patterns, separated
        /// by ";". For example "*.jpg;prog*.exe"</param>
        public static string[] GetFiles(string path, string searchPattern, bool  includeSubFolders)
        {
            string[] patterns = searchPattern.Split(';');
            return GetFiles(path, patterns, includeSubFolders);
        }

        private static void getFiles(string path, string[] searchPattern, ref ArrayList files)
        {
            // Try to get the current directory's folders
            try
            {
                string[] folders = Directory.GetDirectories(path);
                for (int i = 0; i < folders.Length; i++)
                    getFiles(folders[i], searchPattern, ref files);


                for (int i = 0; i < searchPattern.Length; i++)
                {
                    string[] curFiles = Directory.GetFiles(path, searchPattern[i]);
                    files.AddRange(curFiles);
                }
            }
            catch
            { }
        }
        #endregion
    
    }
}

