using System.Text;

namespace EditorCreate
{
    public class EnumEditor : ILoaderEditor
    {
        public void Edit(StringBuilder builder, ILoaderParameter parameter)
        {
            var type_name = parameter.GetTypeName ();
            StringBuilderHelper.EditEnum(builder,string.Format(ResourcesLoaderCreateUtility.enumNameFormat,type_name);
        }
    }
}
