using System.Collections.Generic;
[System.Serializable]
public class JsonArmas
{
    public string nome;
    public string titulo;
}

[System.Serializable]
public class ArmasJson
{
    public List<JsonArmas> listaEspadas;
    public List<JsonArmas> listaCajados;
    public List<JsonArmas> listaMachado;
    public List<JsonArmas> listaMartelos;
    public List<JsonArmas> listaArco;
    public List<JsonArmas> listaBanjo;
}
