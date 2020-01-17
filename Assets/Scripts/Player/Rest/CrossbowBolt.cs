using UnityEngine;

public class CrossbowBolt : MonoBehaviour, IPassFloat
{
    [SerializeField] private float damage;
    [SerializeField] private  ParticleSystem trail;
    private GameObject poolerParent;
    private AudioSource sound;

    private void OnEnable()
    {
        gameObject.layer = 0;
        GetComponent<BoxCollider>().isTrigger = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<BoxCollider>().enabled = true;
        trail.Play();
    }

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        trail = gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        poolerParent = this.transform.parent.gameObject;
    }

    public void PassFloat(float amount)
    {
        damage = amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            other.GetComponent<IDamage>().TakeDamage(damage, PlayerExtension.GetPlayerObject().transform.position);
            if (other.tag != "Imp")
            {
                AttachToBody(other);
            }
            sound.PlayOneShot(sound.clip, 0.1f);
            Invoke("DisableObject", 13f);
            trail.Stop();
        }

        if (other.gameObject.layer == 14)
        {
            TurnOffBody();
            sound.PlayOneShot(sound.clip, 0.1f);
            Invoke("DisableObject", 13f);
            trail.Stop();
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

    public void DisableObject()
    {
        gameObject.layer = 12;
        transform.parent = poolerParent.transform;
        this.gameObject.SetActive(false);
    }
}
