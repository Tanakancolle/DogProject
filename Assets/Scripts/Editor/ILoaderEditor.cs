using System.Text;

namespace EditorCreate
{
    public interface ILoaderEditor
    {
        void Edit(StringBuilder builder, ILoaderParameter parameter);
    }
}
