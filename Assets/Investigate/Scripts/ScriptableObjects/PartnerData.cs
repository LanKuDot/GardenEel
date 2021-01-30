using UnityEngine;

namespace Investigate
{
    [CreateAssetMenu(
        menuName = "Data/Partner Data",
        fileName = "PartnerData")]
    public class PartnerData : ScriptableObject
    {
        [SerializeField]
        private int _id = 0;
        [SerializeField]
        private Sprite _componentSprite = null;
        [SerializeField]
        private GardenEel.BodyType _componentType = GardenEel.BodyType.Body;
        [SerializeField]
        private float _freeMovingRadius = 0.5f;
        [SerializeField]
        private Vector2 _freeMovingIntervalRange = new Vector2(1, 2);

        public int id => _id;
        public Sprite componentSprite => _componentSprite;
        public GardenEel.BodyType componentType => _componentType;
        public float freeMovingRadius => _freeMovingRadius;
        public Vector2 freeMovingInvervalRange => _freeMovingIntervalRange;
    }
}
