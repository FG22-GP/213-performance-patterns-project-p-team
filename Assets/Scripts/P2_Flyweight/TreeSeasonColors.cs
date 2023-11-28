using System;
using UnityEngine;

namespace P2_Flyweight {
    [Serializable]
    public class TreeSeasonColors {
        public ColorInfo[] colors;
        private int _index;

        /// <summary>
        ///     OBSOLETE! This returns the current color. The value changes every time
        ///     `MoveNext` is invoked.
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
        ///     OBSOLETE! This makes the Tree move on to the next color
        /// </summary>
        public void MoveNext() {
            _index += 10;
            _index %= colors.Length;
        }

        public Color GetColour(int index) {
            var colorInfo = colors[index];
            return new Color(colorInfo.r, colorInfo.g, colorInfo.b, 1f);
        }
    }
}