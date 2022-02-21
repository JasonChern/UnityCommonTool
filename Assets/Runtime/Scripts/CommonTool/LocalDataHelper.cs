using UnityEngine;

namespace com.FunJimChee.CommonTool
{
    public static class LocalDataHelper
    {
        public static bool TryLoad<T>(string key, out T handle) where T : class, new()
        {
            var result = LoadSaveManager.TryLoad(Application.streamingAssetsPath, key, out handle);

            return result;
        }

        public static bool TryWrite<T>(T data, string key, bool useOverride = true) where T : class, new()
        {
            var result = LoadSaveManager.TryWrite(data, Application.streamingAssetsPath, key, useOverride);

            return result;
        }

        public static void Delete(string key)
        {
            LoadSaveManager.Delete(Application.streamingAssetsPath, key);
        }
    }
}