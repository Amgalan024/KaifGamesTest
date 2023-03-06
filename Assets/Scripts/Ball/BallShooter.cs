using System.Collections;
using UI;
using UnityEngine;

namespace Ball
{
    public class BallShooter : MonoBehaviour
    {
        [SerializeField] private int _maxBalls;
        [SerializeField] private float _shootCoolDown;
        [SerializeField] private float _reloadCoolDown;
        [SerializeField] private int _reloadAmount;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private BallSpawner _ballSpawner;
        [SerializeField] private BallsCounter _ballsCounter;
        [SerializeField] private TapZone _tapZone;
        [SerializeField] private Camera _camera;

        private int _availableBalls;
        private bool _canShoot;

        private void Start()
        {
            _tapZone.OnClick += ShootBall;

            _availableBalls = _maxBalls;
            _ballsCounter.Initialize(_maxBalls);
            _canShoot = true;

            StartCoroutine(ReloadCoroutine());
        }

        private void OnDestroy()
        {
            _tapZone.OnClick -= ShootBall;
        }

        private void ShootBall(Vector3 touchPosition)
        {
            if (_availableBalls <= 0 || _canShoot == false)
            {
                return;
            }

            _availableBalls--;

            _ballsCounter.RemoveBalls(1);

            var destination = GetDestination(touchPosition);

            var ball = _ballSpawner.GetBall();

            ball.BallMovement.SetPosition(_shootPoint.position);
            ball.BallMovement.SetDestination(destination);

            StartCoroutine(ShootCoolDownCoroutine());
        }

        private Vector3 GetDestination(Vector3 touchPosition)
        {
            var nearPos = new Vector3(touchPosition.x, touchPosition.y, _camera.nearClipPlane);
            var farPos = new Vector3(touchPosition.x, touchPosition.y, _camera.farClipPlane);

            var nearPosConverted = _camera.ScreenToWorldPoint(nearPos);
            var farPosConverted = _camera.ScreenToWorldPoint(farPos);

            var missedDirection = nearPosConverted + farPosConverted;

            if (Physics.Raycast(nearPosConverted, farPosConverted - nearPosConverted, out RaycastHit hit,
                    Mathf.Infinity))
            {
                return hit.point;
            }
            else
            {
                return missedDirection;
            }
        }

        private IEnumerator ShootCoolDownCoroutine()
        {
            _canShoot = false;

            yield return new WaitForSeconds(_shootCoolDown);

            _canShoot = true;
        }

        private IEnumerator ReloadCoroutine()
        {
            while (true)
            {
                yield return new WaitUntil(() => _availableBalls < _maxBalls);

                yield return TimerCoroutine();
            }
        }

        private IEnumerator TimerCoroutine()
        {
            var time = _reloadCoolDown;

            _ballsCounter.SetTimerActive(true);

            while (time >= 0f)
            {
                _ballsCounter.SetTimerValue(time);

                time -= Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            _ballsCounter.SetTimerActive(false);
            _ballsCounter.AddBalls(_reloadAmount);

            _availableBalls++;
        }
    }
}