using UnityEngine;

namespace P2_Flyweight {
    public class TreeData : MonoBehaviour {
        public static TreeSeasonColors TreeSeasonColors { get; private set; }

        private void Awake() {
            LoadColourInfo();
        }
        
        private static void LoadColourInfo() {
            var fileContents = Resources.Load<TextAsset>("treeColors").text;
            TreeSeasonColors = JsonUtility.FromJson<TreeSeasonColors>(fileContents);
        }
    }
}