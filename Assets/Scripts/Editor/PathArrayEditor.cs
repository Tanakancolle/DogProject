using EditorCreate;
using System.Text;

namespace EditorCreate
{
    public class PathArrayEditor : ILoaderEditor
    {
        public void Edit(StringBuilder builder, ILoaderParameter parameter, int tab_num, string[] paths) 
        {
            string tab = StringBuilderHelper.SetTab (tab_num);

            builder.AppendLine (string.Format ("{0}private static readonly string[] {1} = new string[]", 
                tab, 
                string.Format (ResourcesLoaderCreateUtility.pathArrayFormat, parameter.GetName ())));
            
            builder.AppendLine (tab + "{");
            builder.AppendLine (StringBuilderHelper.JoinStrings (paths, tab_num + 1, ",\n", "\"", "\""));
            builder.AppendLine (tab + "};");
        }

        public string[] GetUsings()
        {
            return null;
        }
    }
}
