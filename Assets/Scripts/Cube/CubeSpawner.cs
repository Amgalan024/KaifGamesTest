using UnityEngine;

namespace Cube
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private MovementArea.MovementArea _movementArea;

        public Cube SpawnCube()
        {
            var cube = Instantiate(_cubePrefab, _movementArea.GetRandomPoint(), Quaternion.identity);

            cube.CubeMovement.SetMovementArea(_movementArea);

            return cube;
        }
    }
}