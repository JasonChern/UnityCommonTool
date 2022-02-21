using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.FunJimChee.CommonTool;
using com.FunJimChee.ThreadTool;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.skin.button.fontSize = 36;

        var path = @"C:\Users\Jason\Desktop\TT";

        var oldPath = $@"{path}\old";
        var newPath = $@"{path}\TT\TT\new";
        
        if (GUILayout.Button("Test"))
        {
            DirectoryHelper.MoveFolder(oldPath, newPath);
        }

        if (GUILayout.Button("Test2"))
        {
            DirectoryHelper.CopyFolder(oldPath, newPath, false);
        }

        if (GUILayout.Button("TT"))
        {
            var s = new ThreadHelperModel();

            s.UpdateEvent += (message) =>
            {
                Debug.Log($"{message.Result}");
            };

            s.FinishEvent += () =>
            {
                Debug.Log("Finished!");
            };

            for (int i = 0; i < 10; i++)
            {
                var time = Random.Range(1000, 5000);
                
                s.AddTask(() =>
                {
                    Task.Delay(time).Wait();
                    
                    Debug.Log(time);
                });
            }
            
            s.Run(100);
        }
    }
}
