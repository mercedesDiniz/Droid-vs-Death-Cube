using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.SceneManager;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoNivel;
    [SerializeField] private GameObject painelMenuPrincipl; // Painel do menu principal
    [SerializeField] private GameObject painelOpcoes; // Painel de opções

    public void Jogar(){
        SceneManager.LoadScene(nomeDoNivel); // Carrega o nível 
    }
    
    public void AbrirOpcoes(){
        painelMenuPrincipl.SetActive(false); // Desativa o painel do menu principal
        painelOpcoes.SetActive(true); // Ativa o painel de opções
    }

    public void FecharOpcoes(){
        painelMenuPrincipl.SetActive(true); // Ativa o painel do menu principal
        painelOpcoes.SetActive(false); // Desativa o painel de opções
    }

    public void SairJogo(){
        Debug.Log("Sair do Jogo");
        Application.Quit(); // Encerra o aplicativo/jogo
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


