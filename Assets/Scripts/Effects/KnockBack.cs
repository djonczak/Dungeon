using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float _knockBackStrenght = 22f;
    [SerializeField] private bool _canBeKnockBack = true;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void KnockBackEffect(Vector3 position)
    {
        if (_canBeKnockBack)
        {
            var direction = (transform.position - position).normalized;

            _rb.AddForce(_rb.velocity + direction * _knockBackStrenght, ForceMode.Impulse);
        }
    }
}
