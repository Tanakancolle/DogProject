
using UnityEngine;

namespace EditorCreate
{
    public class TextureLoaderParameter : ILoaderParameter
    {
        public string GetName()
        {
            return "Texture";
        }

        public string[] GetTargetExtensions()
        {
            return new string[] { "png", "jpg" };
        }

        public string GetTypeName()
        {
            return typeof (Texture).Name;
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
