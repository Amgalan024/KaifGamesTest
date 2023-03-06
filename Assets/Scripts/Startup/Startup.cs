using System;
using Ball;
using Cube;
using UnityEngine;

namespace Startup
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private BallShootingController _ballShootingController;
        [SerializeField] private CubesSpawnController _cubesSpawnController;

        private void Start()
        {
            _ballShootingController.Initialize();
            _cubesSpawnController.Initialize();
        }
    }
}