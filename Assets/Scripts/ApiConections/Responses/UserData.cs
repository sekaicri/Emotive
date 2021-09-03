using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UserData : MonoBehaviour
{
    public static UserData Instance { get; private set; }
    public Usuario usuario;
    public List<Item> items;
    [HideInInspector]
    public Item item;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }




}

