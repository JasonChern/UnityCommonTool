namespace com.FunJimChee.CommonTool
{
    using UnityEngine;

    public abstract class MonoSingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                _instance = FindObjectOfType<T>();

                if (_instance != null) return _instance;

                var typeName = typeof(T).Name;
                
                Debug.Log($"Create MonoSingletonBase By {typeName}");

                var component = new GameObject(typeName).AddComponent<T>();

                _instance = component;

                return _instance;
            }
        }
    }
}