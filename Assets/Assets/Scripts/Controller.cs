﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Controller : MonoBehaviour {
    public Flowchart fc;
    public static Controller cont;
    public Clickable2D c2d;
    public int eyeUsedCounter;

	//Bools to check if you've passed certain parts of a given conversation
	public bool spokeToColleen;
	public bool colleenConfessed;
	public bool spokeToEllen;

	// Use this for initialization
    public void getCurrentMap()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Flowchart");
        fc = go.GetComponent<Flowchart>();
        GameObject eye = GameObject.FindGameObjectWithTag("Eye");
        if (eye != null)
        {
            c2d = eye.GetComponent<Clickable2D>();
        }
    }
	//}

    void Awake()
    {
        if (cont == null)
        {
            DontDestroyOnLoad(gameObject);
            cont = this;
        }
        else if (cont != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        if (fc == null)
        {
            getCurrentMap();
        }
        if (c2d != null)
        {
            bool tempBool = fc.GetBooleanVariable("hideEye");
            SpriteRenderer sr = c2d.GetComponent<SpriteRenderer>();
            sr.enabled = !tempBool;
        }
    }

    void addEyeUse()
    {
        getCurrentMap();
        eyeUsedCounter++;
        fc.SetIntegerVariable("eyeUsedCounter", eyeUsedCounter);
        Debug.Log("called!");
    }
}
