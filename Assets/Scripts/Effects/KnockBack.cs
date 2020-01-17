using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float knockBackStrenght = 22f;
    [SerializeField] private bool canBeKnockBack = true;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void KnockBackEffect(Vector3 position)
    {
        if (canBeKnockBack)
        {
            var direction = (transform.position - position).normalized;

            rb.AddForce(rb.velocity + direction * knockBackStrenght, ForceMode.Impulse);
        }
    }
}
