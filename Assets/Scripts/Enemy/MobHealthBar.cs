using UnityEngine;

public class MobHealthBar : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthbar;
    [SerializeField] private float _yOffset = 0;

    private void Start()
    {
        gameObject.transform.rotation = Camera.main.transform.rotation;
        transform.position = new Vector3(transform.position.x,  transform.position.y + _yOffset, transform.position.z);
    }

    private void LateUpdate()
    {
        gameObject.transform.rotation = Quaternion.identity;
    }

    public void ChangeHPBar(float currentHP, float maxHP)
    {
        healthbar.fillAmount = currentHP / maxHP;
    }
}
