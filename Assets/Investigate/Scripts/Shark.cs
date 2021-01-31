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
        private Vector2[] _spawnPoints;
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
            RandomSpawnPoint();
            StartCoroutine(FreeMoving());
            StartCoroutine(SpriteChanging());
        }

        private void RandomSpawnPoint()
        {
            var id = Random.Range(0, _spawnPoints.Length);
            transform.position = _spawnPoints[id];
        }

        private IEnumerator FreeMoving()
        {
            var freeMovingTimeout = 60.0f;
            var curTime = 0.0f;

            while (curTime < freeMovingTimeout) {
                _direction =
                    Quaternion.Euler(0, 0, Random.Range(0, 360)) * Vector3.up;

                var waitTime = Random.Range(
                    _freeMovingIntervalRange.x,
                    _freeMovingIntervalRange.y);
                yield return new WaitForSeconds(waitTime);

                curTime += waitTime;
            }

            _tracingRange = 1000.0f;
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
