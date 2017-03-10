using System.Text;

namespace EditorCreate
{
    public class GetNameEditor : ILoaderEditor
    {
        private static readonly string argumentEnumName = "type";
        
        public void Edit(StringBuilder builder, ILoaderParameter parameter, int tab_num, string[] paths)
        {
            string tab = StringBuilderHelper.SetTab (tab_num);
            builder.AppendLine (string.Format ("{0}public static string {1}({2} {3})", 
                tab, 
                string.Format(ResourcesLoaderCreateUtility.getPathMethodFormat,parameter.GetName()),
                string.Format (ResourcesLoaderCreateUtility.enumNameFormat, parameter.GetName ()), 
                argumentEnumName));

            builder.AppendLine (tab + "{");
            tab_num++;
            tab = StringBuilderHelper.SetTab (tab_num);
            {
                builder.AppendLine (string.Format ("{0}return {1}[(int){2}];",
                    tab,
                    string.Format (ResourcesLoaderCreateUtility.pathArrayFormat, parameter.GetName ()),
                    argumentEnumName));
            }
            tab_num--;
            tab = StringBuilderHelper.SetTab (tab_num);
            builder.AppendLine (tab + "}");
        }

        public string[] GetUsings()
        {
            return null;
        }
    }
}