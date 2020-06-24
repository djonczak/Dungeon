using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Adventurer.Player
{
    public class AdventurerHealth : MonoBehaviour, IDamage
    {
        public Image HPBar;

        [SerializeField] private float _maxHP = 0f;
        [SerializeField] private float _currentHP = 0f;

        private bool _isDamaged;

        private Animator _anim;
        private Coroutine _damageCooldown;

        private const string _dead = "Dead";

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void Start()
        {
            _currentHP = _maxHP;
        }

        public void TakeDamage(float amount, Vector3 enemyPosition)
        {
            if (_isDamaged == false)
            {
                _currentHP -= amount;
                HPBar.fillAmount = _currentHP / _maxHP;
                _damageCooldown = StartCoroutine(DamageCooldown(1f));
                GetComponent<IDamageEffect>().DamageEffect();
                AdventurerEvent.PlayerHit();
                if (CheckIfAlive())
                {
                    StopCoroutine(_damageCooldown);
                    Die();
                }
            }
        }

        private bool CheckIfAlive()
        {
            return _currentHP <= 0;
        }

        private void Die()
        {
            _anim.SetTrigger(_dead);
            GetComponent<AdventurerController>().enabled = false;
        }

        private IEnumerator DamageCooldown(float time)
        {
            _isDamaged = true;
            yield return new WaitForSeconds(time);
            _isDamaged = false;
        }
    }
}
