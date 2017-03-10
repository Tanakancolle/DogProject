using UnityEditor;
using UnityEngine;

namespace EditorCreate
{
    public class ResourcesLoaderCreateWindow : EditorWindow
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static ResourcesLoaderCreateWindow instance;

        /// <summary>
        /// ウィンドウ生成
        /// </summary>                      
        [MenuItem ("Tools/Resources Loader")]
        public static void CreateWindow()
        {
            if (instance == null) {
                instance = CreateInstance<ResourcesLoaderCreateWindow> ();
            }

            instance.titleContent = new GUIContent ("ResourcesLoader");
            instance.ShowUtility ();
        }

        /// <summary>
        /// オプション
        /// </summary>
        private ResourcesLoaderCreateOption option = new ResourcesLoaderCreateOption();

        private void OnGUI()
        {
            option.createPath = EditorGUILayout.TextField ("生成パス", option.createPath);
            
            if (GUILayout.Button("OK")) {
                var resources = new ResourcesLoaderCreater ();
                resources.Create (option);
            }
        }
    }
}
