
using System;

namespace EditorCreate
{
    public class AllLoaderParameter : ILoaderParameter
    {
        /// <summary>
        /// 名前取得
        /// </summary>
        /// <returns>名称</returns>
        public string GetName()
        {
            return "Resources";
        }

        /// <summary>
        /// 対象拡張子配列取得
        /// </summary>
        /// <returns>対象拡張子配列</returns>
        public string[] GetTargetExtensions()
        {
            return new string[] { "*" };
        }

        /// <summary>
        /// タイプ名取得
        /// </summary>
        /// <returns>タイプ名</returns>
        public string GetTypeName()
        {
            return string.Empty;
        }

        /// <summary>
        /// 宣言するUsing取得
        /// </summary>
        /// <returns>宣言するUsing</returns>
        public string[] GetUsings()
        {
            return null;
        }
    }
}
