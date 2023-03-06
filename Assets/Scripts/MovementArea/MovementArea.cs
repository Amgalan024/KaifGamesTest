using UnityEngine;

namespace MovementArea
{
    public class MovementArea : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        public Vector3 GetRandomPoint()
        {
            var bounds = _collider.bounds;

            var minX = bounds.center.x - bounds.size.x / 2;
            var maxX = bounds.center.x + bounds.size.x / 2;

            var minZ = bounds.center.z - bounds.size.z / 2;
            var maxZ = bounds.center.z + bounds.size.z / 2;

            var maxY = bounds.center.y + bounds.size.y / 2;

            var randomX = Random.Range(minX, maxX);
            var randomZ = Random.Range(minZ, maxZ);

            var vector = new Vector3(randomX, maxY, randomZ);

            vector = transform.TransformPoint(vector);

            return vector;
        }
    }
}