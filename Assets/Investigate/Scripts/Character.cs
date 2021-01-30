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

        protected void MovePosition(Vector2 targetPosition)
        {
            _rigidbody.MovePosition(targetPosition);
        }

        protected void AddImpulseForce(Vector2 force)
        {
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
