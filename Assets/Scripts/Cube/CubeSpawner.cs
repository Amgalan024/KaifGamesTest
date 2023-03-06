using System.Collections;
using UI;
using UnityEngine;

namespace Cube
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private MovementArea.MovementArea _movementArea;
        [SerializeField] private float _minRespawnTime;
        [SerializeField] private float _maxRespawnTime;
        [SerializeField] private CubesCounter _cubesCounter;

        public void SpawnCube()
        {
            var cube = Instantiate(_cubePrefab, _movementArea.GetRandomPoint(), Quaternion.identity);

            cube.OnCubeDestroyed += HandleCubeDestruction;

            cube.CubeMovement.SetMovementArea(_movementArea);
        }

        private void HandleCubeDestruction(Cube cube)
        {
            _cubesCounter.IncreaseCount();

            StartCoroutine(RespawnCubeCoroutine());

            cube.OnCubeDestroyed -= HandleCubeDestruction;
        }

        private IEnumerator RespawnCubeCoroutine()
        {
            var randomDelay = Random.Range(_minRespawnTime, _maxRespawnTime);

            yield return new WaitForSeconds(randomDelay);

            SpawnCube();
        }
    }
}