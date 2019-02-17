#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public class MakeScriptableObject
{
    [MenuItem("Assets/Create/It")]
    public static void CreateMyAsset()
    {
        ColorInfo asset = ScriptableObject.CreateInstance<ColorInfo>();

        AssetDatabase.CreateAsset(asset, "Assets/ColorInfo.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
#endif