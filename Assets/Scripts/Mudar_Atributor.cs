using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using TipagemClasses;
using System.Linq;
using System.Collections.Generic;

public class Mudar_Atributor : MonoBehaviour
{   
    public TextMeshProUGUI ca;
    public TextMeshProUGUI hp;
    public TextAsset Classes;
    public DndClassesData clastipagem;
    public TextAsset jsonracas;
    public TextAsset racas;
    private RacaEfeitos racas_efeitos;
    public TextMeshProUGUI pontos_disponiveis;
    private int valor_hp;
    private PlayerData_SO player;
    public Upar up;
    private int pts;
    private List<string> lista_classes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void OnEnable()
    {
        clastipagem = JsonConvert.DeserializeObject<DndClassesData>(Classes.text);
        racas_efeitos= JsonUtility.FromJson<RacaEfeitos>(jsonracas.text);
        pontos_disponiveis.text = "20";
        player = DadosJogador.Instance_jogador.playerData;
        pts = Ponto_Inicias.pontos;
        lista_classes = clastipagem.Classes.Keys.ToList();

        player.ca=10+racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.ca+ Utils.CalcularModificador(player.destreza+1);
        player.carisma = racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.carisma+8;
        player.forca = racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.forca+8;
        player.inteligencia = racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.inteligencia+8;
        player.destreza = racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.destreza+8;
        player.contituicao = racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.contituicao+8;
        player.sabedoria = racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.sabedoria+8;
        DadosJogador.Instance_jogador.NotifyStatsChanged();
        ca.text = (10+racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.ca+ Utils.CalcularModificador(player.destreza+1)).ToString();
        valor_hp =clastipagem.Classes[lista_classes[DadosJogador.Instance_jogador.playerData.characterClass]].Life;
        player.hp = valor_hp;
        hp.text = valor_hp.ToString();
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
        }
        else
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
        Debug.Log(racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.ca);
        if(player.destreza == 20 ||pts<=0){

        }
        else{
            pts = pts-1;
            player.ca=10+racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.ca+ Utils.CalcularModificador(player.destreza+1);
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
            player.ca=10+racas_efeitos.racas[DadosJogador.Instance_jogador.playerData.race].add.ca+Utils.CalcularModificador(player.destreza-1);
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
            hp.text = (valor_hp + Utils.CalcularModificador(player.contituicao+1)).ToString();
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
            hp.text = (valor_hp + Utils.CalcularModificador(player.contituicao-1)).ToString();
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
}
