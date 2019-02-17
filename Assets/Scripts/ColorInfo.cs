using UnityEngine;

public class ColorInfo : ScriptableObject {

    public ColorItem[] items;

    [System.Serializable]
	public class ColorItem {
        public Color color;
        public string name;
    }
}
