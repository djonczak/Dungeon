using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealthBar : MonoBehaviour
{
    public UnityEngine.UI.Image healthbar;
    [SerializeField] private float _yOffset = 0;

    private void Start()
    {
        gameObject.transform.rotation = Camera.main.transform.rotation;
        transform.position = new Vector3(transform.position.x, _yOffset, transform.position.z);
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
