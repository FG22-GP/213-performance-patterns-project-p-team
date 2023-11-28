using System;
using UnityEngine;

[Serializable]
public class TreeSeasonColors
{
    [SerializeField] private ColorInfo[] colors;
    
    /// <summary>
    /// This returns the current color. The value changes every time
    /// `MoveNext` is invoked.
    /// </summary>
    public Color CurrentColor
    {
        get
        {
            var colorInfo = colors[_index];
            return new Color(colorInfo.r, colorInfo.g, colorInfo.b, 1f);
        }
    }

    /// <summary>
    /// This makes the Tree move on to the next color
    /// </summary>
    public void MoveNext()
    {
        _index += 10;
        _index %= colors.Length;
    }

    private int _index;
}