using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private InputController controls;

    private void Awake()
    {
        controls = new InputController();

        controls.UI.Submit.performed += input => LoadSceneMode();
    }

    public void LoadSceneMode()
    {
        SceneManager.LoadScene("CombatTest");
    }

    private void OnEnable()
    {
        controls.UI.Enable();
    }
}
