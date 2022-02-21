using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace com.FunJimChee.CommonTool
{
    public static class LoadSaveManager
    {
        public static bool TryLoad<T>(string dirPath, string fileName, out T handle) where T : class, new()
        {
            try
            {
                var path = $"{dirPath}/{fileName}.json";

                var json = File.ReadAllText(path, Encoding.UTF8);

                handle = JsonConvert.DeserializeObject<T>(json);

                return true;
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message);

                handle = null;

                return false;
            }
        }
        
        public static bool TryWrite<T>(T data, string dirPath, string fileName, bool useOverride = true) where T : class, new()
        {
            try
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                
                var path = $"{dirPath}/{fileName}.json";

                var finalPath = path;

                if (!useOverride)
                {
                    var index = 1;

                    while (File.Exists(finalPath))
                    {
                        finalPath = $"{dirPath}/{fileName} ({index}).json";

                        index++;
                    }
                }

                var str = JsonConvert.SerializeObject(data);

                File.WriteAllText(finalPath, str, Encoding.UTF8);

                return true;
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message);

                return false;
            }
        }

        public static void Delete(string dirPath, string fileName)
        {
            var path = $"{dirPath}/{fileName}.json";
            
            File.Delete(path);
        }
    }
}