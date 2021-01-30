using UnityEngine;

namespace Investigate
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody = null;

        protected float velocity => _rigidbody.velocity.magnitude;

        private void Reset()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
            _rigidbody.useFullKinematicContacts = true;
        }

        protected void MovePosition(Vector2 deltaPosition)
        {
            _rigidbody.MovePosition((Vector2)transform.position + deltaPosition);
            SetLookDirection(deltaPosition.x);
        }

        protected void AddImpulseForce(Vector2 force)
        {
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
            SetLookDirection(force.x);
        }

        private void SetLookDirection(float xValue)
        {
            var localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * Mathf.Sign(xValue);
            transform.localScale = localScale;
        }
    }
}
