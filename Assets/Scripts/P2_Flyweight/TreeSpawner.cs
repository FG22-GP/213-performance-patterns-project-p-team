using P1_Pooling;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace P2_Flyweight {
    [RequireComponent(typeof(TreeData))]
    public class TreeSpawner : MonoBehaviour {
        private const float TotalCooldown = 0.2f;
        [FormerlySerializedAs("TreePrefab")] public Tree treePrefab;
        private float _currentCooldown;

        private TreeData _treeData;

        private void Start() {
            _treeData = GetComponent<TreeData>();
        }

        private void FixedUpdate() {
            _currentCooldown -= Time.deltaTime;
            if (!(_currentCooldown <= 0f)) {
                return;
            }

            _currentCooldown += TotalCooldown;
            SpawnTree();
        }

        private void SpawnTree() {
            var randomPositionX = Random.Range(-6f, 6f);
            var randomPositionY = Random.Range(-6f, 6f);
            Instantiate(treePrefab, new Vector2(randomPositionX, randomPositionY), Quaternion.identity);
        }
    }
}