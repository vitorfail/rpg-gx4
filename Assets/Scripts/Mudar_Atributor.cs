using Newtonsoft.Json;
using UnityEngine;


public class Mudar_Atributor : MonoBehaviour
{   
    private PlayerData_SO player;
    public Upar up;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = DadosJogador.Instance_jogador.playerData;
    }
    public void Add_Carisma()
    {
        player.carisma = player.carisma+1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
        up.UpCarisma();
    } 
    public void Sub_Carisma()
    {
        player.carisma = player.carisma-1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
    } 
    public void Add_Forca()
    {
        player.forca = player.forca+1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
        up.UpForca();
    } 
    public void Sub_Forca()
    {
        player.forca = player.forca-1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
    }
    public void Add_Inteligencia()
    {
        player.inteligencia = player.inteligencia+1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
        up.UpInteligencia();
    } 
    public void Sub_Inteligencia()
    {
        player.inteligencia = player.inteligencia-1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
    }  
    public void Add_Destreza()
    {
        player.destreza = player.destreza+1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
        up.UpDestreza();
    } 
    public void Sub_Destreza()
    {
        player.destreza = player.destreza-1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
    } 
    public void Add_Constituicao()
    {
        player.contituicao = player.contituicao+1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
        up.UpConstituicao();
    } 
    public void Sub_Constituicao()
    {
        player.contituicao = player.contituicao-1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
    } 
    public void Add_Sabedoria()
    {
        player.sabedoria = player.sabedoria+1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
        up.UpSabedoria();
    } 
    public void Sub_Sabedoria()
    {
        player.sabedoria = player.sabedoria-1;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
    } 
}
