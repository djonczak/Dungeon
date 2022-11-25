using UnityEngine;

namespace Combat.Projectile
{
    public class CrossbowBolt : MonoBehaviour, IPassFloat
    {
        [SerializeField] private float _damage;
        [SerializeField] private ParticleSystem _trail;
        private GameObject _poolerParent;
        private AudioSource _sound;

        private const string Imp = "Imp";
        private const string DisableObject = "DisableObjectAfterTime";

        private void OnEnable()
        {
            gameObject.layer = 0;
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxCollider>().enabled = true;
            _trail.Play();
        }

        private void Awake()
        {
            _sound = GetComponent<AudioSource>();
            _trail = gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        }

        private void Start()
        {
            _poolerParent = this.transform.parent.gameObject;
        }

        public void PassFloat(float amount)
        {
            _damage = amount;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 10)
            {
                other.GetComponent<IDamage>().TakeDamage(_damage, PlayerExtension.GetPlayerObject().transform.position);
                if (!other.CompareTag(Imp))
                {
                    AttachToBody(other);
                }
                _sound.PlayOneShot(_sound.clip, 0.1f);
                Invoke(DisableObject, 13f);
                _trail.Stop();
            }

            if (other.gameObject.layer == 14)
            {
                TurnOffBody();
                _sound.PlayOneShot(_sound.clip, 0.1f);
                Invoke(DisableObject, 13f);
                _trail.Stop();
            }
        }

        private void AttachToBody(Collider other)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            var spine = other.transform.GetChild(0).gameObject;
            transform.parent = spine.transform;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
        }

        private void TurnOffBody()
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().useGravity = true;
        }

        public void DisableObjectAfterTime()
        {
            gameObject.layer = 12;
            transform.parent = _poolerParent.transform;
            this.gameObject.SetActive(false);
        }
    }
}
