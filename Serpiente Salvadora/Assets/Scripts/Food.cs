using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float _cantidadPuntos = 100f;
    [SerializeField] private Puntaje _putaje;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _putaje.SumarPuntos(_cantidadPuntos);
    }
}
