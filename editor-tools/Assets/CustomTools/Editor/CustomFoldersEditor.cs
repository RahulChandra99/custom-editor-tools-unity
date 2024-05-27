using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


#if UNITY_EDITOR
using UnityEditor;

namespace RC
{
    [InitializeOnLoad]

    static class CustomFoldersEditor
    {
        static string selectedFolderGuid;
        static int controlID;

        static CustomFoldersEditor()
        {
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        private static void OnGUI(string guid, Rect selectionRect)
        {
            if (guid != selectedFolderGuid)
                return;

            if(Event.current.commandName == "ObjectSelectorUpdated" && EditorGUIUtility.GetObjectPickerControlID() == controlID)
            {
                UnityEngine.Object selectedObject = EditorGUIUtility.GetObjectPickerObject();

                string folderTexGuid = AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(selectedObject)).ToString();

                Debug.Log(folderTexGuid);

                EditorPrefs.SetString(selectedFolderGuid, folderTexGuid);
            }
        }

        public static void ChooseCustomIcon()
        {
            selectedFolderGuid = Selection.assetGUIDs[0];


            controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
            EditorGUIUtility.ShowObjectPicker<Sprite>(null, false, "", controlID);
        }
    }
}

#endif
