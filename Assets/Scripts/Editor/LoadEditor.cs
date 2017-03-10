using System.Text;

namespace EditorCreate
{
    public class LoadEditor : ILoaderEditor
    {
        private static readonly string argumentName = "type";

        public void Edit(StringBuilder builder, ILoaderParameter parameter, int tab_num, string[] paths)
        {
            var tab = StringBuilderHelper.SetTab (tab_num);
            string type_name = parameter.GetTypeName ();
            string method_name = parameter.GetName ();
            string method_after = string.Empty;

            if (string.IsNullOrEmpty (type_name)) {
                type_name = "T";
                method_name += "<T>";
                method_after = " where T : Object";
            }

            builder.AppendLine (string.Format ("{0}public static {1} Load{2}({3} {4}){5}", 
                tab, 
                type_name, 
                method_name, 
                string.Format (ResourcesLoaderCreateUtility.enumNameFormat, parameter.GetName ()), 
                LoadEditor.argumentName,
                method_after));

            builder.AppendLine (tab + "{");
            tab = StringBuilderHelper.SetTab (tab_num + 1);
            {
                builder.AppendLine (string.Format ("{0}return Resources.Load<{1}> ({2} ({3}));",
                    tab,
                    type_name,
                    string.Format (ResourcesLoaderCreateUtility.getPathMethodFormat, parameter.GetName ()),
                    LoadEditor.argumentName));
            }
            tab = StringBuilderHelper.SetTab (tab_num);
            builder.AppendLine (tab + "}");
        }

        public string[] GetUsings()
        {
            return new string[] { "UnityEngine" };
        }
    }
}
