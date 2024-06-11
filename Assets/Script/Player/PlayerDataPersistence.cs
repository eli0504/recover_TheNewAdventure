using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataPersistence : MonoBehaviour
{
    public static PlayerDataPersistence instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
