using System.Text;

namespace EditorCreate
{
    public interface ILoaderEditor : IUsings
    {
        /// <summary>
        /// 記述
        /// </summary>
        void Edit(StringBuilder builder, ILoaderParameter parameter, int tab_num, string[] paths);
    }
}
