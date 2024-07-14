using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace RC
{

    static class MenuItems
    {
        const int priority = 10000;

        [MenuItem("Assets/CustomTools(Folder Icon)/Red", false, priority)]
        static void Red()
        {
            ColoredFolders.SetIconName("Red");
        }

        [MenuItem("Assets/CustomTools(Folder Icon)/Green", false, priority)]
        static void Green()
        {
            ColoredFolders.SetIconName("Green");
        }

        [MenuItem("Assets/CustomTools(Folder Icon)/Blue", false, priority)]
        static void Blue()
        {
            ColoredFolders.SetIconName("Blue");
        }
        
        

        [MenuItem("Assets/CustomTools(Folder Icon)/CustomIcon", false, priority + 11)]
        static void CustomIcon()
        {
            CustomFoldersEditor.ChooseCustomIcon();
        }

        [MenuItem("Assets/CustomTools(Folder Icon)/ResetIcon", false, priority + 23)]
        static void ResetIcon()
        {
            Debug.Log("Icon set to Default");
            ColoredFolders.ResetFolderIcon();
        }

        [MenuItem("Assets/CustomTools(Folder Icon)/Red", true)]
        [MenuItem("Assets/CustomTools(Folder Icon)/Green", true)]
        [MenuItem("Assets/CustomTools(Folder Icon)/Blue", true)]
        [MenuItem("Assets/CustomTools(Folder Icon)/CustomIcon", true)]
        [MenuItem("Assets/CustomTools(Folder Icon)/ResetIcon", true)]
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