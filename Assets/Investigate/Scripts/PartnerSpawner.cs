using UnityEngine;

namespace Investigate
{
    public class PartnerSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _partnerPrefab = null;
        [SerializeField]
        private PartnerData[] _datas = null;
        [SerializeField]
        private Rect _spawnArea = Rect.zero;

        private void Start()
        {
            SpawnPartners();
        }

        private void SpawnPartners()
        {
            foreach (var data in _datas) {
                var spawnPosition =
                    new Vector3(
                        Random.Range(_spawnArea.xMin, _spawnArea.xMax),
                        Random.Range(_spawnArea.yMin, _spawnArea.yMax));
                var obj =
                    Instantiate(
                        _partnerPrefab, spawnPosition, Quaternion.identity);
                obj.name = data.name;
                var partner = obj.GetComponent<Partner>();
                partner.Initialize(data);
            }
        }
    }
}
