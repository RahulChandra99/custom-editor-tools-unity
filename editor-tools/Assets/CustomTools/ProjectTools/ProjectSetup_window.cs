using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Windows;

namespace RC
{
    public class ProjectSetup_window : EditorWindow
    {
        static ProjectSetup_window win;
        static string projectName = "_MyProject";

        public static void InitWindow()
        {
            win = EditorWindow.GetWindow<ProjectSetup_window>("Project Setup");
            win.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            projectName = EditorGUILayout.TextField("Project Name :" ,projectName);
            EditorGUILayout.EndHorizontal();

            if(GUILayout.Button("Create Project Structure", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
            {
                CreateProjectFolders();
            }

            
            GUILayout.Label("It is recommanded to start project name with '_' to keep it on the top.");
            

            if (win != null)
            {
                win.Repaint();
            }
        }

        void CreateProjectFolders()
        {
            if(string.IsNullOrEmpty(projectName))
            {
                Debug.Log("Enter a name");
                return;
            }

            if(projectName == "_MyProject")
            {

            }

            string assetPath = Application.dataPath;
            string rootPath = assetPath + "/" + projectName;

            Directory.CreateDirectory(rootPath);

            AssetDatabase.Refresh();
        }

        void CloseWindow()
        {
            if(win)
            {
                win.Close();
            }
        }

        
    }
}


