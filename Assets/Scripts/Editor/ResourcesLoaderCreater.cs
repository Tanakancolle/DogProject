using System.Text;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace EditorCreate
{
    public class ResourcesLoaderCreater
    {
        /// <summary>
        /// パラメーター配列
        /// </summary>
        private ILoaderParameter[] parameters = new ILoaderParameter[] {
            new AllLoaderParameter(),
            new TextureLoaderParameter(),
            new AudioClipLoaderParameter(),
        };

        /// <summary>
        /// エディタ配列
        /// </summary>
        private ILoaderEditor[] editors = new ILoaderEditor[] {
            new EnumEditor(),
            new PathArrayEditor(),
            new GetNameEditor(),
            new LoadEditor(),
        };

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="option">オプション</param>
        public void Create(ResourcesLoaderCreateOption option)
        {
            var builder = new StringBuilder ();

            var class_name = Path.GetFileNameWithoutExtension (option.createPath);

            var tab_num = 0;
            var tab = StringBuilderHelper.SetTab (tab_num);

            // Using記述
            EditUsings (builder, tab);

            // 改行
            builder.AppendLine ();

            // クラス定義開始
            builder.AppendLine (string.Format ("{0}public static class {1}", tab, class_name));
            builder.AppendLine (tab + "{");
            {   
                tab_num++;
                tab = StringBuilderHelper.SetTab (tab_num);

                // パラメーターごとに処理
                foreach (var parameter in parameters) {
                    builder.AppendLine (string.Format ("#region {0}", parameter.GetName ()));

                    // パス取得
                    var paths = ResourcesLoaderCreateUtility.GetPathsInResourcesFolder (parameter.GetTargetExtensions ());
                    if (paths.Length == 0) {
                        paths = new string[] { "dummy" };
                    }

                    // エディタごとに処理
                    foreach (var editor in editors) {
                        editor.Edit (builder, parameter, tab_num, paths);
                        builder.AppendLine ();
                    }

                    builder.AppendLine (string.Format ("#endregion"));
                    builder.AppendLine ();
                }

                tab_num--;
                tab = StringBuilderHelper.SetTab (tab_num);
            }
            builder.AppendLine (tab + "}");

            // スクリプト生成
            StringBuilderHelper.CreateScript (option.createPath + ".cs", builder.ToString (), true);
            StringBuilderHelper.RefreshEditor ();
        }

        /// <summary>
        /// Using記述
        /// </summary>
        private void EditUsings(StringBuilder builder, string tab)
        {
            // IUsingsリスト生成
            var iusings_list = new List<IUsings> ();
            iusings_list.AddRange (parameters);
            iusings_list.AddRange (editors);

            // 使用するUsing取得
            var using_list = new HashSet<string> ();
            foreach (var iusings in iusings_list) {
                var usings = iusings.GetUsings ();
                if (usings == null || usings.Length == 0) {
                    continue;
                }

                foreach( var using_name in usings ) {
                    using_list.Add (using_name);
                }
            }

            // Using記述
            foreach (var using_name in using_list) {
                builder.AppendLine (string.Format ("{0}using {1};", tab, using_name));
            }
        }
    }
}
