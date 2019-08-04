using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Framework
{
    public static class DirectoryUtility
    {
        /// <summary>
        /// 判断路径是否存在
        /// </summary>
        public static bool Exists(string path)
        {
            return System.IO.Directory.Exists(path);
        }

        /// <summary>
        /// 创建目录,如果存在则不动作
        /// </summary>
        public static void New(string path)
        {
            if (!Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 创建路径
        /// </summary>
        /// <param name="path"></param>
        public static void NewPath(string path)
        {
            string testPath = "";

            string[] direactor = path.Split(new char[] { '\\' });

            foreach(string dir in direactor)
            {
                testPath = testPath + (testPath==""?"":"\\") + dir;

                New(testPath);
            }
        }

        /// <summary>
        /// 拷贝文件夹及其子目录
        /// </summary>
        /// <param name="sourceDir">数据源</param>
        /// <param name="destDir">目标文件夹</param>
        /// <param name="copySubDirs">是否拷贝子目录</param>
        public static void DirectoryCopy (string sourceDir, string destDir, bool copySubDirs )
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sourceDir);
            System.IO.DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new System.IO.DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDir);
            }

            // 如果目标文件夹不存在，创建
            if (!DirectoryUtility.Exists(destDir))
            {
                System.IO.Directory.CreateDirectory(destDir);
            }


            // Get the file contents of the directory to copy.
            System.IO.FileInfo[] files = dir.GetFiles();

            foreach (System.IO.FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = System.IO.Path.Combine(destDir, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (System.IO.DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = System.IO.Path.Combine(destDir, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        
        /// <summary>
        /// 获取文件夹下所有文件路径
        /// </summary>
        /// <param name="folderPath">文件夹路径</param>
        /// <param name="containsSubfolder">是否包含子文件夹</param>
        public static IList<string> GetFiles(string folderPath, bool containsSubfolder)
        {
            IList<string> fileList = null;

            if (!containsSubfolder)
            {
                fileList = System.IO.Directory.GetFiles(folderPath).ToList<string>();
            }
            else
            {
                fileList = System.IO.Directory.GetFiles(folderPath).ToList<string>();

                //找出所有子文件夹
                string[] folders = System.IO.Directory.GetDirectories(folderPath);

                foreach (string folder in folders)
                {
                    IList<string> filesSub = GetFiles(folder, containsSubfolder);

                    fileList = fileList.Concat<string>(filesSub).ToList<string>();
                }
            }

            return fileList;
        }

        /// <summary>  
        /// 删除目录下所有文件  
        /// </summary>  
        /// <param name="folderPath">路径</param>  
        public static void DeleteDirector(string folderPath)
        {
            try
            {
                //目录是否存在  
                if (Exists(folderPath))
                {
                    // 检查目标目录是否以目录分割字符结束如果不是则添加之  
                    if (folderPath[folderPath.Length - 1] != Path.DirectorySeparatorChar)
                    {
                        folderPath += Path.DirectorySeparatorChar;
                    }

                    // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组  
                    // 如果你指向Delete目标文件下面的文件而不包含目录请使用下面的方法  
                    string[] fileList = Directory.GetFiles(folderPath);

                    //string[] fileList = Directory.GetFileSystemEntries(aimPath);  
                    // 遍历所有的文件和目录  
                    foreach (string file in fileList)
                    {
                        // 先当作目录处理如果存在这个目录就递归Delete该目录下面的文件  
                        if (Directory.Exists(file))
                        {
                            DeleteDirector(folderPath + Path.GetFileName(file));
                        }
                        // 否则直接Delete文件  
                        else
                        {
                            File.Delete(folderPath + Path.GetFileName(file));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }  

    }
}
