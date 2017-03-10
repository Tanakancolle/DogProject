
using UnityEngine;

namespace EditorCreate
{
    public class AudioClipLoaderParameter : ILoaderParameter
    {
        public string GetName()
        {
            return "Sound";
        }

        public string[] GetTargetExtensions()
        {
            return new string[] { "mp3", "wav" };
        }

        public string GetTypeName()
        {
            return typeof (AudioClip).Name;
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
