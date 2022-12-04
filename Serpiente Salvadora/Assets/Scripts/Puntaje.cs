using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Puntaje : MonoBehaviour
{
    [SerializeField] private float _puntos;
    [SerializeField] private TextMeshProUGUI _textMesh;

    private void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _puntos += Time.deltaTime;
        _textMesh.text = _puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        _puntos += puntosEntrada;
    }
}
