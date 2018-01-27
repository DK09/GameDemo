using UnityEngine;

public static class UITools
{
    private static RectTransform _mainCanvasRT = null;

    public static RectTransform MainCanvasRT
    {
        get
        {
            if (_mainCanvasRT == null)
            {
                _mainCanvasRT = GameObject.Find("Canvas").GetComponent<RectTransform>();
            }

            return _mainCanvasRT;
        }
    }

    public static RectTransform FindByPath(string path)
    {
        return FindByPath(MainCanvasRT, path);
    }

    public static RectTransform FindByPath(RectTransform parent, string path)
    {
        return parent.Find(path) as RectTransform;
    }
}