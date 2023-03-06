using UnityEngine;

namespace Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        private Vector3 _destination;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, _movementSpeed * Time.deltaTime);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
        }
    }
}