using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Raquete1 : MonoBehaviour
{
    public float velocidade = 3.5f;
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical1");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalMovement * velocidade);
    }
}