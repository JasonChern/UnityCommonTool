using System;
using Newtonsoft.Json;
using UnityEngine;

namespace com.FunJimChee.CommonTool
{
    public static class PlayerPrefsHelper
    {
        public static bool TryLoad<T>(string key, out T handle) where T : class, new()
        {
            try
            {
                var json = PlayerPrefs.GetString(key);

                if (string.IsNullOrEmpty(json))
                {
                    handle = null;

                    return false;
                }

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

        public static void Save<T>(string key, T data) where T : class, new()
        {
            var json = JsonConvert.SerializeObject(data);
            
            if(string.IsNullOrEmpty(json)) return;
            
            PlayerPrefs.SetString(key, json);
        }

        public static void Delete(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}