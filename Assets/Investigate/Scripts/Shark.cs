using System.Collections;
using UnityEngine;

namespace Investigate
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Shark : Character
    {
        #region Serialized Fields

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Sprite[] _sprites;
        [SerializeField]
        private Vector2 _freeMovingIntervalRange = new Vector2(2.0f, 3.0f);
        [SerializeField]
        private float _movingVelocity = 5.0f;
        [SerializeField]
        private float _tracingVelocity = 20.0f;
        [SerializeField]
        private float _tracingRange = 20.0f;

        #endregion

        private Vector2 _direction;
        private bool _closeToPlayer;
        private const float _spriteChangingInterval = 0.4f;

        private void Reset()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            StartCoroutine(FreeMoving());
            StartCoroutine(SpriteChanging());
        }

        private IEnumerator FreeMoving()
        {
            while (true) {
                _direction =
                    Quaternion.Euler(0, 0, Random.Range(0, 360)) * Vector3.up;

                yield return new WaitForSeconds(
                    Random.Range(
                        _freeMovingIntervalRange.x,
                        _freeMovingIntervalRange.y));
            }
        }

        private IEnumerator SpriteChanging()
        {
            var curSpriteID = 0;

            while (true) {
                _spriteRenderer.sprite = _sprites[curSpriteID];
                curSpriteID = (int) Mathf.Repeat(++curSpriteID, _sprites.Length);
                yield return new WaitForSeconds(_spriteChangingInterval);
            }
        }

        private void FixedUpdate()
        {
            var towardVector =
                (Vector2) (GardenEel.Instance.position - transform.position);
            var distanceToGardenEel = towardVector.magnitude;
            var velocity = _movingVelocity;

            if (distanceToGardenEel < _tracingRange) {
                _direction = towardVector.normalized;
                velocity = _tracingVelocity;
            }

            MovePosition(
                (Vector2) transform.position
                + velocity * Time.deltaTime * _direction);
        }
    }
}
