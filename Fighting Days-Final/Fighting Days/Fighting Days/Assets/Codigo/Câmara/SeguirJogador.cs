using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJogador : MonoBehaviour
{
    public Transform Jogador;
    public float smoothing;
    public Vector3 offset;

    void FixedUpdate()
    {
        if (Jogador != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, Jogador.transform.position + offset, smoothing);
            transform.position = newPosition;
        }
    }
}
