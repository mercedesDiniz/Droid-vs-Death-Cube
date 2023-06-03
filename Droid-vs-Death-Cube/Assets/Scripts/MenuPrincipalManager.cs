using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.SceneManager;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoNivel;
    [SerializeField] private GameObject painelMenuPrincipl;
    [SerializeField] private GameObject painelOpcoes;

    public void Jogar(){
        SceneManager.LoadScene(nomeDoNivel);
    }

    public void AbrirOpcoes(){
        painelMenuPrincipl.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes(){
        painelMenuPrincipl.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void SairJogo(){
        Debug.Log("Sair do Jogo");
        Application.Quit();
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


