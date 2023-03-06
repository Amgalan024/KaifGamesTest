using Cube;
using UnityEngine;

namespace Startup
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private CubeSpawner _cubeSpawner;
        [SerializeField] private int _cubesAmount;

        private void Start()
        {
            for (int i = 0; i < _cubesAmount; i++)
            {
                _cubeSpawner.SpawnCube();
            }
        }
    }
}