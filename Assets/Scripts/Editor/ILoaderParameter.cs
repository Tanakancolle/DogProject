
namespace EditorCreate
{
    public interface ILoaderParameter : IUsings
    {
        /// <summary>
        /// 名称取得
        /// </summary>
        string GetName();

        /// <summary>
        /// 対象拡張子配列取得
        /// </summary>
        string[] GetTargetExtensions();

        /// <summary>
        /// タイプ名取得
        /// </summary>
        string GetTypeName();
    }
}
