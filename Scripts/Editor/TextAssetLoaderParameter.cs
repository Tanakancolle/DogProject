﻿
using UnityEngine;

namespace EditorCreate
{
    public class TextAssetLoaderParameter : ILoaderParameter
    {
        public string GetName()
        {
            return "TextAsset";
        }

        public string[] GetTargetExtensions()
        {
            return new string[] {
                "txt","html","htm","xml","bytes","json","csv","yaml","fnt"
            };
        }

        public string GetTypeName()
        {
            return GetName ();
        }

        public string[] GetUsings()
        {
            return new string[] { "UnityEngine" };
        }
    }
}
