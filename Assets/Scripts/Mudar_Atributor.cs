using Newtonsoft.Json;
using TMPro;
using UnityEngine;


public class Mudar_Atributor : MonoBehaviour
{   
    public TextMeshProUGUI ca;
    public TextMeshProUGUI pontos_disponiveis;
    private PlayerData_SO player;
    public Upar up;
    private int pts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pontos_disponiveis.text = "20";
        player = DadosJogador.Instance_jogador.playerData;
        pts = Ponto_Inicias.pontos;
    }
    public void Add_Carisma()
    {
        if(player.carisma == 20 || pts<=0)
        {
            
        }
        else
        {
            pts = pts-1;
            pontos_disponiveis.text = pts.ToString();
            player.carisma = player.carisma+1;
            DadosJogador.Instance_jogador.NotifyStatsChanged();
            up.UpCarisma();
        }
    } 
    public void Sub_Carisma()
    {
        if(player.carisma == 8)
        {
        }
        else
        {
            pts = pts+1;
            player.carisma = player.carisma-1;
            pontos_disponiveis.text = pts.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
        }
    } 
    public void Add_Forca()
    {
        if(player.forca == 20 ||pts<=0){

        }
        else{
            pts = pts-1;
            player.forca = player.forca+1;
            pontos_disponiveis.text = pts.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
            up.UpForca();
        }
    } 
    public void Sub_Forca()
    {
        if(player.forca == 8)
        {
            pts = pts+1;
            player.forca = player.forca-1;
            pontos_disponiveis.text = pts.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
        }
    }
    public void Add_Inteligencia()
    {
        if(player.inteligencia == 20 || pts<=0){

        }
        else{
            pts = pts-1;
            player.inteligencia = player.inteligencia+1;
            pontos_disponiveis.text = pts.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
            up.UpInteligencia();
        }
        
    } 
    public void Sub_Inteligencia()
    {
        if(player.inteligencia == 8)
        {
            
        }
        else
        {
            pts = pts+1;
            player.inteligencia = player.inteligencia-1;
            pontos_disponiveis.text = pts.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
        }
    }  
    public void Add_Destreza()
    {
        if(player.destreza == 20 ||pts<=0){

        }
        else{
            pts = pts-1;
            player.ca=10+ CalcularModificador(player.destreza+1);
            player.destreza = player.destreza+1;
            pontos_disponiveis.text = pts.ToString();
            ca.text = player.ca.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
            up.UpDestreza();
        }  
    } 
    public void Sub_Destreza()
    {
        if(player.destreza == 8)
        {
            
        }
        else
        {
            pts = pts+1;
            player.ca=10+ CalcularModificador(player.destreza-1);
            player.destreza = player.destreza-1;
            pontos_disponiveis.text = pts.ToString();
            ca.text = player.ca.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
        }
    } 
    public void Add_Constituicao()
    {
        if(player.contituicao == 20|| pts<=0){

        }
        else{
            pts = pts-1;
            player.contituicao = player.contituicao+1;
            pontos_disponiveis.text = pts.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
            up.UpConstituicao();
        }
    } 
    public void Sub_Constituicao()
    {
        if(player.contituicao == 8)
        {
            
        }
        else
        {
            pts = pts+1;
            player.contituicao = player.contituicao-1;
            pontos_disponiveis.text = pts.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
        }
    } 
    public void Add_Sabedoria()
    {
        if(player.sabedoria == 20 || pts<=0){

        }
        else{
            pts = pts-1;
            player.sabedoria = player.sabedoria+1;
            pontos_disponiveis.text = pts.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
            up.UpSabedoria();
        }
    } 
    public void Sub_Sabedoria()
    {
        if(player.sabedoria == 8)
        {
            
        }
        else
        {
            pts = pts+1;
            player.sabedoria = player.sabedoria-1;
            pontos_disponiveis.text = pts.ToString();
            DadosJogador.Instance_jogador.NotifyStatsChanged();
        }
    } 
    int CalcularModificador(int atributo)
    {
        return (atributo - 10) / 2;
    }
}
