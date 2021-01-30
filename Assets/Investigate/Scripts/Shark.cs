using System.Collections;
using UnityEngine;

namespace Investigate
{
    public class Shark : Character
    {
        [SerializeField]
        private Vector2 _freeMovingIntervalRange = new Vector2(2.0f, 3.0f);
        [SerializeField]
        private float _movingVelocity = 5.0f;
        [SerializeField]
        private float _tracingVelocity = 20.0f;
        [SerializeField]
        private float _tracingRange = 20.0f;

        private Vector2 _direction;
        private bool _closeToPlayer;

        private void Start()
        {
            StartCoroutine(FreeMoving());
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
