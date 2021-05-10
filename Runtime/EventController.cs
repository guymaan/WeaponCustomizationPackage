using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    private static EventController _instance;
    
    public static EventController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EventController>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public UnityEvent onChosenWeapon;
    public UnityEvent onAttachmentChange;
    public UnityEvent onStart;
}

