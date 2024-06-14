using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Raquete2 : MonoBehaviour
{
    public float velocidade = 3.5f;
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical2");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalMovement * velocidade);
    }
}