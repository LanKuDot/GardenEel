using System;
using UnityEngine;

namespace Investigate
{
    public class GardenEel : Character
    {
        #region Enums

        public enum BodyType
        {
            Head = 0,
            Body = 1,
            Tail = 2,
            NUM_OF_TYPE
        }

        #endregion

        #region Data Getters

        public static GardenEel Instance { get; private set; }
        public Vector3 position => transform.position;

        #endregion

        #region Values

        [SerializeField]
        private Animator _animator = null;
        [SerializeField]
        private float _maxGatheringTime = 2.0f;
        [SerializeField]
        private Vector2 _movingForceRange = new Vector2(5.0f, 10.0f);

        #endregion

        #region Controlling Properties

        private float _gatheringTime;
        private readonly int _velocityParamID = Animator.StringToHash("velocity");

        #endregion

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (GameplayManager.Instance.isPausing)
                return;

            if (Input.GetMouseButtonDown(0))
                _gatheringTime = 0.0f;
            else if (Input.GetMouseButton(0))
                _gatheringTime =
                    Math.Min(_gatheringTime + Time.deltaTime, _maxGatheringTime);
            else if (Input.GetMouseButtonUp(0))
                SetMoving();

            _animator.SetFloat(_velocityParamID, velocity);
        }

        private void SetMoving()
        {
            var selfScreenPos = Camera.main.WorldToScreenPoint(transform.position);
            var directionVector =
                Input.mousePosition - selfScreenPos;
            directionVector = directionVector.normalized;
            var forceAmount =
                Mathf.Lerp(
                    _movingForceRange.x,
                    _movingForceRange.y,
                    Mathf.InverseLerp(0, _maxGatheringTime, _gatheringTime));
            AddImpulseForce(directionVector * forceAmount);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Partner"))
                SelectComponent(other.gameObject.GetComponent<Partner>().data);
        }

        private void SelectComponent(PartnerData data)
        {
            GameplayManager.Instance.SelectComponent(data);
        }
    }
}
