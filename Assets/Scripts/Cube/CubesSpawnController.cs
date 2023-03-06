using System.Collections;
using UI;
using UnityEngine;

namespace Cube
{
    public class CubesSpawnController : MonoBehaviour
    {
        [SerializeField] private int _cubesAmount;
        [SerializeField] private float _minRespawnTime;
        [SerializeField] private float _maxRespawnTime;
        [SerializeField] private CubeSpawner _cubeSpawner;
        [SerializeField] private CubesCounter _cubesCounter;

        public void Initialize()
        {
            for (int i = 0; i < _cubesAmount; i++)
            {
                InitializeCube();
            }
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

            InitializeCube();
        }

        private void InitializeCube()
        {
            var cube = _cubeSpawner.SpawnCube();

            cube.OnCubeDestroyed += HandleCubeDestruction;
        }
    }
}