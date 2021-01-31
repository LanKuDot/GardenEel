using System.Collections;
using UnityEngine;

namespace Investigate
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Partner : Character
    {
        #region Serialize Fields

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Vector2 _spriteChangingIntervalRange = new Vector2(0.1f, 0.5f);
        [SerializeField]
        private Vector2 _freeMovingRadiusRange = new Vector2(0.5f, 1.0f);
        [SerializeField]
        private Vector2 _freeMovingIntervalRange = new Vector2(1.0f, 2.0f);

        #endregion

        private PartnerData _data;
        private const float _lerpFactor = 0.2f;

        private Vector2 _startPosition;
        private Vector2 _targetPosition;
        private float _spriteChangingInterval;
        private float _freeMovingRadius;

        #region Data Getters

        public PartnerData data => _data;

        #endregion

        private void Reset()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Initialize(PartnerData data)
        {
            _data = data;
            _spriteChangingInterval =
                Random.Range(
                    _spriteChangingIntervalRange.x,
                    _spriteChangingIntervalRange.y);
            _startPosition = transform.position;
            _freeMovingRadius =
                Random.Range(
                    _freeMovingRadiusRange.x, _freeMovingRadiusRange.y);

            transform.localScale = Vector3.one * data.spriteScale;
        }

        private void Start()
        {
            StartCoroutine(FreeMoving());
            StartCoroutine(SpriteChanging());
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
                    _freeMovingRadius *
                    new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

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
                _spriteRenderer.sprite = _data.sprites[curSpriteID];
                curSpriteID = (int) Mathf.Repeat(++curSpriteID, _data.sprites.Length);

                yield return new WaitForSeconds(_spriteChangingInterval);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}
