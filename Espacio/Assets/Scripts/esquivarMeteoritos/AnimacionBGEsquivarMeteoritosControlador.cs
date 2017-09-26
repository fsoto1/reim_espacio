﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimacionBGEsquivarMeteoritosControlador : EsquivarMeteoritosControlador
{
    public float scrollSpeed;
    private Vector2 savedOffset;

    void Start()
    {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float y = Mathf.Repeat(Time.time * nav.modelo.Velocidad_background, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }

}