using System.Text;
using System.Linq;
using System.IO;

namespace EditorCreate
{
    public class EnumEditor : ILoaderEditor
    {
        public void Edit(StringBuilder builder, ILoaderParameter parameter, int tab_num, string[] paths)
        {
            StringBuilderHelper.EditEnum (
                builder,
                string.Format (ResourcesLoaderCreateUtility.enumNameFormat, parameter.GetName ()),
                paths.Select (p => Path.GetFileNameWithoutExtension (p)).ToArray (),
                1);
        }

        public string[] GetUsings()
        {
            return null;
        }
    }
}
