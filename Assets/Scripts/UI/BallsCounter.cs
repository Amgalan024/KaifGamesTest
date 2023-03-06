using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BallsCounter : MonoBehaviour
    {
        [SerializeField] private Text _timerText;
        [SerializeField] private Image _chargeIcon;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;

        private List<Image> _ballIcons;

        public void Initialize(int maxBallsAmount)
        {
            _ballIcons = new List<Image>(maxBallsAmount);

            for (int i = 0; i < maxBallsAmount; i++)
            {
                var icon = Instantiate(_chargeIcon, _gridLayoutGroup.transform);

                _ballIcons.Add(icon);
            }
        }

        public void AddBalls(int amount)
        {
            SetIconsActive(true, amount);
        }

        public void RemoveBalls(int amount)
        {
            SetIconsActive(false, amount);
        }

        public void SetTimerActive(bool value)
        {
            _timerText.enabled = value;
        }

        public void SetTimerValue(float time)
        {
            _timerText.text = time.ToString("0.00");
        }

        private void SetIconsActive(bool value, int amount)
        {
            foreach (var image in _ballIcons.Where(b => b.isActiveAndEnabled == !value).Take(amount))
            {
                image.gameObject.SetActive(value);
            }
        }
    }
}