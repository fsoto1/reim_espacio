using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoverFondo : MonoBehaviour
{
    public float velocidad;
    public bool ejeX;
    private Vector2 savedOffset;
    private float x;
    private float y;

    void Start()
    {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        if (ejeX)
        {
            x = Mathf.Repeat(Time.time * velocidad, 1);
            Vector2 offset = new Vector2(x, savedOffset.y);
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
        else
        {
            y = Mathf.Repeat(Time.time * velocidad, 1);
            Vector2 offset = new Vector2(savedOffset.x, y);
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
    }

    void OnDisable()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }

}
