﻿using System;
using UnityEngine;

namespace Investigate
{
    public class GardenEel : Character
    {
        public static GardenEel Instance { get; private set; }

        #region Values

        [SerializeField]
        private Animator _animator = null;
        [SerializeField]
        private float _maxGatheringTime = 2.0f;
        [SerializeField]
        private Vector2 _movingForceRange = new Vector2(5.0f, 10.0f);

        #endregion

        #region Controlling Properties

        private const KeyCode _gatheringKey = KeyCode.Space;
        private float _gatheringTime;
        private readonly int _velocityParamID = Animator.StringToHash("velocity");

        #endregion

        private void Update()
        {
            if (Input.GetKeyDown(_gatheringKey))
                _gatheringTime = 0.0f;
            else if (Input.GetKey(_gatheringKey))
                _gatheringTime =
                    Math.Min(_gatheringTime + Time.deltaTime, _maxGatheringTime);
            else if (Input.GetKeyUp(_gatheringKey))
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

            SetLookDirection(directionVector.x);
        }

        private void SetLookDirection(float xValue)
        {
            var localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * Mathf.Sign(xValue);
            transform.localScale = localScale;
        }
    }
}
