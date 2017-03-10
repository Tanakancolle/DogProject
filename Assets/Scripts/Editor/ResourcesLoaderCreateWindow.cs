using UnityEditor;


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
        public static void CreateWindow()
        {
            if (instance == null) {
                instance = CreateInstance<ResourcesLoaderCreateWindow> ();
            }

            instance.titleContent = new UnityEngine.GUIContent ("ResourcesLoader");
            instance.ShowUtility ();
        }

        private void OnGUI()
        {
            
        }
    }
}
