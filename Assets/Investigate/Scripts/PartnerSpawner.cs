using UnityEngine;

namespace Investigate
{
    public class PartnerSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _partnerPrefabs = null;
        [SerializeField]
        private Rect _spawnArea = Rect.zero;

        private void Start()
        {
            SpawnPartners();
        }

        private void SpawnPartners()
        {
            foreach (var prefab in _partnerPrefabs) {
                var spawnPosition =
                    new Vector3(
                        Random.Range(_spawnArea.xMin, _spawnArea.xMax),
                        Random.Range(_spawnArea.yMin, _spawnArea.yMax));
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
