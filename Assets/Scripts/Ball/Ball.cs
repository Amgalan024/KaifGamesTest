using UnityEngine;

namespace Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private BallMovement _ballMovement;
        [SerializeField] private float _destructionZoneSize;

        public BallMovement BallMovement => _ballMovement;

        private void OnTriggerEnter(Collider other)
        {
            DestroyCubes();
            Destroy(gameObject);
        }

        private void DestroyCubes()
        {
            var overlapColliders = Physics.OverlapSphere(transform.position, _destructionZoneSize);

            foreach (var overlappedCollider in overlapColliders)
            {
                if (overlappedCollider.attachedRigidbody.TryGetComponent(out Cube.Cube cube))
                {
                    cube.DestroyCube();
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(transform.position, _destructionZoneSize);
        }
    }
}