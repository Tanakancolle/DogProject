using EditorCreate;
using System.Text;
using System.Linq;

namespace EditorCreate
{
    public class PathArrayEditor : ILoaderEditor
    {
        private static readonly string removeWord = "Resources/";
        private static readonly int removeWordLength = removeWord.Length;

        public void Edit(StringBuilder builder, ILoaderParameter parameter, int tab_num, string[] paths) 
        {
            string tab = StringBuilderHelper.SetTab (tab_num);

            if (paths[0] != ResourcesLoaderCreateUtility.dummyPath) {
                paths = paths
                    .Select (p => p.Substring (p.IndexOf (PathArrayEditor.removeWord) + PathArrayEditor.removeWordLength))
                    .Select (p => p.Remove (p.LastIndexOf (".")))
                    .ToArray ();
            }

            builder.AppendLine (string.Format ("{0}private static readonly string[] {1} = new string[]",
                tab,
                ResourcesLoaderCreateUtility.GetPathArrayName (parameter)));
            
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
