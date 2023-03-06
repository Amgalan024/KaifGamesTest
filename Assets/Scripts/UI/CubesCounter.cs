using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CubesCounter : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private int _count;

        private void Start()
        {
            _text.text = "0";
        }

        public void IncreaseCount()
        {
            _count++;

            _text.text = _count.ToString();
        }
    }
}