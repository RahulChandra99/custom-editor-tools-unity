using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace RC
{

    static class MenuItems
    {
        const int priority = 100000;

        [MenuItem("Assets/RC/Choose Icon or Color/Red", false, priority)]
        static void Red()
        {
            ColoredFolders.SetIconName("Red");
        }

        [MenuItem("Assets/RC/Choose Icon or Color/Green", false, priority)]
        static void Green()
        {
            ColoredFolders.SetIconName("Green");
        }

        [MenuItem("Assets/RC/Choose Icon or Color/Blue", false, priority)]
        static void Blue()
        {
            ColoredFolders.SetIconName("Blue");
        }

        [MenuItem("Assets/RC/Choose Icon or Color/CustomIcon", false, priority + 11)]
        static void CustomIcon()
        {
            ColoredFolders.ResetFolderIcon();
        }

        [MenuItem("Assets/RC/Choose Icon or Color/ResetIcon", false, priority + 23)]
        static void ResetIcon()
        {
            Debug.Log("Icon set to Default");
            ColoredFolders.ResetFolderIcon();
        }

        [MenuItem("Assets/RC/Choose Icon or Color/Red", true)]
        [MenuItem("Assets/RC/Choose Icon or Color/Green", true)]
        [MenuItem("Assets/RC/Choose Icon or Color/Blue", true)]
        [MenuItem("Assets/RC/Choose Icon or Color/CustomIcon", true)]
        [MenuItem("Assets/RC/Choose Icon or Color/ResetIcon", true)]
        static bool ValidateFunction()
        {
            if(Selection.activeObject == null)
            {
                return false;
            }

            /*Only allow menu options for folders*/

            Object selectedObject = Selection.activeObject; 

            string objectPath = AssetDatabase.GetAssetPath(selectedObject);
            return AssetDatabase.IsValidFolder(objectPath);
            

        }

    }

}



#endif