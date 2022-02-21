using System;
using System.IO;
using UnityEngine;

namespace com.FunJimChee.CommonTool
{
    public static class DirectoryHelper
    {
        public static void MoveFolder(string oldDirPath, string newDirPath)
        {
            var finalPath = newDirPath;
            
            try
            {
                if (!Directory.Exists(finalPath))
                {
                    var parentDirInfo = new DirectoryInfo(finalPath).Parent;

                    if (parentDirInfo is {Exists: false})
                    {
                        parentDirInfo.Create();
                    }
                }
                else
                {
                    var index = 0;

                    while (Directory.Exists($"{finalPath} ({index})"))
                    {
                        index++;
                    }

                    finalPath = $"{finalPath} ({index})";
                }

                Directory.Move(oldDirPath, finalPath);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }

        public static void CopyFolder(string sourceDirPath, string newDirPath, bool recursive = true)
        {
            try
            {
                var dir = new DirectoryInfo(sourceDirPath);
                
                Directory.CreateDirectory(newDirPath);
                
                foreach (var fileInfo in dir.GetFiles())
                {
                    var targetFilePath = Path.Combine(newDirPath, fileInfo.Name);
                    fileInfo.CopyTo(targetFilePath);
                }

                if (recursive)
                {
                    var dirs = dir.GetDirectories();

                    foreach (var subDir in dirs)
                    {
                        var dirPath = Path.Combine(newDirPath, subDir.Name);
                        CopyFolder(subDir.FullName, dirPath);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }
}