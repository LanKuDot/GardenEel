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
        private Sprite[] _sprites = null;
        [SerializeField]
        private float _spriteScale = 1.0f;
        [SerializeField]
        private Sprite _componentSprite = null;
        [SerializeField]
        private GardenEel.BodyType _componentType = GardenEel.BodyType.Body;
        [SerializeField]
        private Sprite _lastWordSprite = null;
        [SerializeField]
        private Sprite _skillHintSprite = null;

        public int id => _id;
        public Sprite[] sprites => _sprites;
        public float spriteScale => _spriteScale;
        public Sprite componentSprite => _componentSprite;
        public GardenEel.BodyType componentType => _componentType;
        public Sprite lastWordSprite => _lastWordSprite;
        public Sprite skillHintSprite => _skillHintSprite;
    }
}
