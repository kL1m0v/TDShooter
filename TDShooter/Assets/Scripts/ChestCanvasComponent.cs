using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

namespace TopDownShooter
{
    public class ChestCanvasComponent : MonoBehaviour
    {
        private Canvas _canvas;
        [SerializeField]
        private TextMeshProUGUI _displayText;
        [SerializeField]
        private TMP_InputField _inputField;
        private const int _codeSize = 4;
        private StringBuilder _code;
        public event Action OnValueCorrect;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _code = new StringBuilder();
        }

        private void OnEnable()
        {
            _inputField.onEndEdit.AddListener(CheckValue);
        }

        private void CheckValue(string value)
        {
            if (_code.ToString() == value)
            {
                OnValueCorrect?.Invoke();
                _displayText.text = "Open";
            }
            else 
            {
                _displayText.text = "Error";
            }
        }

        private IEnumerator GenerateRandomCode()
        {
            for (int i = 0; i < _codeSize; i++)
            {
                int RandomNumber;
                yield return new WaitForSeconds(0.5f);
                RandomNumber = UnityEngine.Random.Range(0, 10);
                _displayText.text = RandomNumber.ToString();
                _code.Append(RandomNumber.ToString());
                yield return new WaitForSeconds(0.5f);
                _displayText.text = null;

            }
        }

        public void ShowCanvas()
        {
            _canvas.enabled = true;
            StartCoroutine(GenerateRandomCode());
        }

        public void HideCanvas()
        {
            _canvas.enabled = false;
            StopAllCoroutines();
            _code.Clear();
        }
    }
}