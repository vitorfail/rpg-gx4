using UnityEngine;
using System;


public class Arma_ataque : MonoBehaviour
{
    private bool _ataque;
    public event Action<bool> OnAtaqueMudou; // evento dispara quando muda

    public bool ataque
    {
        get => _ataque;
        set
        {
            if (_ataque == value) return; // evita eventos repetidos
            _ataque = value;
            OnAtaqueMudou?.Invoke(_ataque); // notifica todos inscritos
        }
    }
}
