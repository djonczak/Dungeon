using System.Collections;
using UnityEngine;

namespace Utility.UI
{
    public class BlackScreenDisperse : MonoBehaviour
    {
        public UnityEngine.UI.Image blackScreen;

        [SerializeField] private Color _fogMainColor;
        [SerializeField] private Color _alphaColor = new Color(0f, 0f, 0f, 0f);
        [SerializeField] private float _disperseTime = 1f;

        private void OnEnable()
        {
            BlackScreenEvent.OnDisperseBlackScreen += Disperse;
        }

        private void Start()
        {
            if (blackScreen != null)
            {
                _fogMainColor = blackScreen.color;
                blackScreen.enabled = false;
            }
        }

        public void Disperse()
        {
            StartCoroutine(DisperseTimer(_disperseTime));
        }

        private IEnumerator DisperseTimer(float time)
        {
            blackScreen.enabled = true;
            yield return new WaitForSeconds(time);
            var timer = 0f;
            while (timer < time)
            {
                var colorLerp = Color.Lerp(_fogMainColor, _alphaColor, timer / time);
                blackScreen.color = colorLerp;
                timer += Time.deltaTime;
                yield return null;
            }
            blackScreen.enabled = false;
            blackScreen.color = _fogMainColor;
        }

        private void OnDestroy()
        {
            BlackScreenEvent.OnDisperseBlackScreen -= Disperse;
        }
    }
}
