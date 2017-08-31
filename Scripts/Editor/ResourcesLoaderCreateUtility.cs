using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace EditorCreate
{
    public class ResourcesLoaderCreateUtility
    {
        /// <summary>
        /// ダミーパス
        /// </summary>
        public static readonly string dummyPath = "dummy";

        /// <summary>
        /// Enum定義時のフォーマット
        /// </summary>
        private static readonly string enumNameFormat = "e{0}";

        /// <summary>
        /// パス配列フォーマット
        /// </summary>
        private static readonly string pathArrayFormat = "{0}Paths";

        /// <summary>
        /// パス取得関数フォーマット
        /// </summary>
        private static readonly string getPathMethodFormat = "Get{0}Name";

        /// <summary>
        /// 無視拡張子配列
        /// </summary>
        private static readonly string[] ignoreExtensions = {
            ".meta"
        };

        /// <summary>
        /// リソースフォルダ内のファイルパス取得
        /// </summary>
        /// <returns>ファイルパス</returns>
        /// <param name="type_names">タイプ名配列</param>
        public static string[] GetPathsInResourcesFolder(string[] type_names)
        {
            var list = new List<string> ();

            var resouces_paths = Directory.GetDirectories ("Assets", "Resources", SearchOption.AllDirectories);

            foreach (var path in resouces_paths) {
                foreach (var type in type_names) {
                    list.AddRange (
                        Directory.GetFiles (path, "*." + type, SearchOption.AllDirectories).
                        Where (p => !IsExists (Path.GetExtension (p), ignoreExtensions))
                    );
                }
            }

            return list.Select (p => p.Replace ("\\", "/")).ToArray ();
        }

        /// <summary>
        /// 存在チェック
        /// </summary>
        /// <param name="target">対象</param>
        /// <param name="keys">候補配列</param>
        /// <returns>true = 候補に対象と等しいものがある</returns>
        public static bool IsExists(string target, string[] keys)
        {          
            foreach( var key in keys) {
                if(target == key) {
                    return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// Enum名取得
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string GetEnumName(ILoaderParameter parameter)
        {
            return string.Format (enumNameFormat, parameter.GetName ());
        }

        /// <summary>
        /// パス配列名取得
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string GetPathArrayName(ILoaderParameter parameter)
        {
            return string.Format (pathArrayFormat, parameter.GetName ());
        }
             
        /// <summary>
        /// パス取得関数名取得
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string GetPathMethodName(ILoaderParameter parameter)
        {
            return string.Format (getPathMethodFormat, parameter.GetName ());
        }
    }
}