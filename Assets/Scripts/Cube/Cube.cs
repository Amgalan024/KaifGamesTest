using System;
using UnityEngine;

namespace Cube
{
    public class Cube : MonoBehaviour
    {
        public event Action<Cube> OnCubeDestroyed;

        [SerializeField] private CubeMovement _cubeMovement;

        public CubeMovement CubeMovement => _cubeMovement;

        public void DestroyCube()
        {
            Destroy(gameObject);

            OnCubeDestroyed?.Invoke(this);
        }
    }
}