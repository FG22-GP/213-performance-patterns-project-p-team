using UnityEngine;

namespace P2_Flyweight {
    public class Tree : MonoBehaviour {
        private int _colourIndex;
        private SpriteRenderer _spriteRenderer;

        private void Start() {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            UpdateSeason();
        }

        private void FixedUpdate() {
            UpdateSeason();
        }

        private void UpdateSeason() {
            _colourIndex += 10;
            _colourIndex %= TreeData.TreeSeasonColors.colors.Length;
            _spriteRenderer.color = TreeData.TreeSeasonColors.GetColour(_colourIndex);
        }
    }
}