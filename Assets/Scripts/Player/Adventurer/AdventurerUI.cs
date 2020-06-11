using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Adventurer.Player
{
    public class AdventurerUI : MonoBehaviour
    {
        public GameObject itemMessagePanel;
        public Image bloodOverlay;

        [SerializeField] private float _effectDuration = 1.2f;

        private Color _defaultColor;
        private Color _alphaColor = new Color(0f, 0f, 0f, 0f);
        private float _t;
        private bool _isDamaged = false;

        private void OnEnable()
        {
            AdventurerEvent.OnPlayerHurt += GotHurt;
            HUDEvent.OnShowMessage += ShowMessage;
            HUDEvent.OnCloseMessage += CloseMessage;
        }

        private void Start()
        {
            CloseMessage();
            if (bloodOverlay != null)
            {
                _defaultColor = bloodOverlay.color;
                bloodOverlay.color = _alphaColor;
            }
        }

        private void Update()
        {
            if (_isDamaged)
            {
                _t += Time.deltaTime / _effectDuration;
                bloodOverlay.color = Color.Lerp(_defaultColor, _alphaColor, _t);
            }
        }

        public void GotHurt()
        {
            StartCoroutine(DamageEffect(_effectDuration));
        }

        public void ShowMessage(string text)
        {
            itemMessagePanel.SetActive(true);
            itemMessagePanel.GetComponentInChildren<Text>().text = text;
        }

        public void CloseMessage()
        {
            itemMessagePanel.SetActive(false);
        }

        private IEnumerator DamageEffect(float time)
        {
            _isDamaged = true;
            yield return new WaitForSeconds(time);
            _t = 0f;
            _isDamaged = false;

        }

        private void OnDestroy()
        {
            AdventurerEvent.OnPlayerHurt -= GotHurt;
            HUDEvent.OnShowMessage -= ShowMessage;
            HUDEvent.OnCloseMessage -= CloseMessage;
        }
    }
}
