using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BallsCounter : MonoBehaviour
    {
        [SerializeField] private Text _timerText;
        [SerializeField] private Image _ballIcon;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;

        private List<Image> _ballIcons;

        public void Initialize(int maxBallsAmount)
        {
            _ballIcons = new List<Image>(maxBallsAmount);

            for (int i = 0; i < maxBallsAmount; i++)
            {
                var icon = Instantiate(_ballIcon, _gridLayoutGroup.transform);

                _ballIcons.Add(icon);
            }

            _timerText.text = 0.ToString("0.00");
        }

        public void AddBallIcons(int amount)
        {
            SetBallIconsActive(true, amount);
        }

        public void RemoveBallIcons(int amount)
        {
            SetBallIconsActive(false, amount);
        }

        public void SetTimerActive(bool value)
        {
            _timerText.enabled = value;
        }

        public void SetTimerValue(float time)
        {
            _timerText.text = time.ToString("0.00");
        }

        private void SetBallIconsActive(bool value, int amount)
        {
            foreach (var image in _ballIcons.Where(b => b.isActiveAndEnabled == !value).Take(amount))
            {
                image.gameObject.SetActive(value);
            }
        }
    }
}