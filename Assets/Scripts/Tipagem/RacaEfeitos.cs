using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RacaEfeitos
{
    public List<Raca> racas;
}

[Serializable]
public class Raca
{
    public string titulo;
    public string descri;

    public AtributosAdd add;

    public Multiplicadores plus_dano;
    public Multiplicadores plus_atk;

    public ValoresDano dano;
    public ValoresDano ferimento;
}

#region Estruturas Auxiliares

[Serializable]
public class AtributosAdd
{
    public int sabedoria;
    public int inteligencia;
    public int carisma;
    public int forca;
    public int contituicao;
    public int destreza;
    public int ca;
}

[Serializable]
public class Multiplicadores
{
    public float cortante;
    public float perfurante;
    public float concusao;
    public float fogo;
    public float gelo;
    public float eletrico;
    public float acido;
    public float veneno;
    public float radiante;
    public float necrotico;
    public float forca;
    public float psiquico;
}

[Serializable]
public class ValoresDano
{
    public float cortante;
    public float perfurante;
    public float concusao;
    public float fogo;
    public float gelo;
    public float eletrico;
    public float acido;
    public float veneno;
    public float radiante;
    public float necrotico;
    public float forca;
    public float psiquico;
}

#endregion
