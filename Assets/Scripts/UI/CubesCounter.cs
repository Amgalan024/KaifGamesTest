using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CubesCounter : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private int _count;

        public void IncreaseCount()
        {
            _count++;

            _text.text = _count.ToString();
        }
    }
}