using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Language _gameLanguage = Language.Polish;

    public enum Language
    {
        Polish,
        English
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void SetLanguage(Language language)
    {
        _gameLanguage = language;
    }

    public Language ReturnLanguage()
    {
        return _gameLanguage;
    }
}
