using UnityEngine;

namespace Combat.UI 
{
    public class DamageText : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(Random.insideUnitSphere.x, Random.insideUnitSphere.y, 0f) * 0.5f, 2f);
        }

        private void DisableObject()
        {
            gameObject.SetActive(false);
        }
    }
}