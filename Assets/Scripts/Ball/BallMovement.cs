using System.Collections;
using UnityEngine;

namespace Ball
{
    public class BallMovement : MonoBehaviour
    {
        private Vector3 _destination;

        private void Start()
        {
            StartCoroutine(MoveCoroutine());
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
        }

        private IEnumerator MoveCoroutine()
        {
            var velocityVector = GetVelocity() * transform.forward;

            while (transform.position != _destination)
            {
                velocityVector += Physics.gravity * Time.deltaTime;

                transform.position += velocityVector * Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }
        }

        private float GetVelocity()
        {
            var cashedTransform = transform;

            Vector3 fromTo = _destination - cashedTransform.position;
            Vector3 projectionToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

            cashedTransform.rotation = Quaternion.LookRotation(projectionToXZ, Vector3.up);

            float x = projectionToXZ.magnitude;
            float y = fromTo.y;

            float angleInRadians = cashedTransform.rotation.eulerAngles.x * Mathf.Deg2Rad;

            float velocitySquare = (Physics.gravity.y * x * x) /
                                   (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
            float velocity = Mathf.Sqrt(Mathf.Abs(velocitySquare));

            return velocity;
        }
    }
}