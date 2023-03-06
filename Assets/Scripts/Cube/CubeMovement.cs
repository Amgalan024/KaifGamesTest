using System.Collections;
using UnityEngine;

namespace Cube
{
    public class CubeMovement : MonoBehaviour
    {
        private MovementArea.MovementArea _movementArea;

        private Vector3 _destination;

        [SerializeField] private float _minDashDelay;
        [SerializeField] private float _maxDashDelay;
        [SerializeField] private float _dashDuration;
        [SerializeField] private float _dashMultiplier;

        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        private void Start()
        {
            StartCoroutine(DashCoroutine());
            StartCoroutine(MovementCoroutine());

            _destination = _movementArea.GetRandomPoint();
        }

        private void Update()
        {
            MoveToDestination();
            RotateTowardsDestination();
        }

        public void SetMovementArea(MovementArea.MovementArea movementArea)
        {
            _movementArea = movementArea;
        }

        private void MoveToDestination()
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, _movementSpeed * Time.deltaTime);
        }

        private void RotateTowardsDestination()
        {
            var rotation = Quaternion.LookRotation(_destination.normalized);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }

        private IEnumerator DashCoroutine()
        {
            while (true)
            {
                var randomDelay = Random.Range(_minDashDelay, _maxDashDelay);

                yield return new WaitForSeconds(randomDelay);

                _movementSpeed *= _dashMultiplier;

                yield return new WaitForSeconds(_dashDuration);

                _movementSpeed /= _dashMultiplier;
            }
        }

        private IEnumerator MovementCoroutine()
        {
            while (true)
            {
                yield return new WaitUntil(() => transform.position == _destination);

                _destination = _movementArea.GetRandomPoint();
            }
        }
    }
}