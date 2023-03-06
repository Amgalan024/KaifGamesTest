using UnityEngine;

namespace Ball
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private Ball _ballPrefab;

        public Ball GetBall()
        {
            var ball = Instantiate(_ballPrefab);

            return ball;
        }
    }
}