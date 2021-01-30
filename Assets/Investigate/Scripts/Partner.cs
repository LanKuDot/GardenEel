using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Investigate
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Partner : Character
    {
        #region Serialize Fields

        [SerializeField]
        private PartnerData _data = null;

        #endregion

        #region Data Getters

        public PartnerData data => _data;

        #endregion

        private Vector2 _startPosition;
        private Vector2 _targetPosition;
        private const float _lerpFactor = 0.2f;

        private void Awake()
        {
            _startPosition = transform.position;
        }

        private void Start()
        {
            StartCoroutine(FreeMoving());
        }

        private void FixedUpdate()
        {
            var nextPosition =
                Vector2.Lerp(transform.position, _targetPosition, _lerpFactor);
            MovePosition(nextPosition);
        }

        private IEnumerator FreeMoving()
        {
            while (true) {
                _targetPosition =
                    _startPosition +
                    _data.freeMovingRadius *
                    new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

                yield return new WaitForSeconds(
                    Random.Range(
                        _data.freeMovingInvervalRange.x,
                        _data.freeMovingInvervalRange.y));
            }
        }
    }
}
