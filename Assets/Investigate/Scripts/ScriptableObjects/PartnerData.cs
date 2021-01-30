﻿using UnityEngine;

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
        private Sprite _componentSprite = null;
        [SerializeField]
        private GardenEel.BodyType _componentType = GardenEel.BodyType.Body;
        [SerializeField]
        private string _skillExplainStr = "";
        [SerializeField]
        private string _lastWordStr = "";

        public int id => _id;
        public Sprite[] sprites => _sprites;
        public Sprite componentSprite => _componentSprite;
        public GardenEel.BodyType componentType => _componentType;
        public string skillExplainStr => _skillExplainStr;
        public string lastWordStr => _lastWordStr;
    }
}
