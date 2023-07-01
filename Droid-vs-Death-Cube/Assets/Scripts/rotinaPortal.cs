using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaPortal : MonoBehaviour
{
    private rotinaPlayer playerScript; //Referência ao script de controle do jogador
    public GameObject portal0; //Referência do portal 0
    public GameObject portal1; //Referência do portal 1
    public static int quantPillsN1 = 20; //Quantidade de pílulas de comida necessárias para ativar o Portal 0
    public static int quantPillsN2 = 40; // Quantidade de pílulas de comida necessárias para ativar o Portal 1


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();
        portal0 = GameObject.FindGameObjectWithTag("Portal0");
        portal1 = GameObject.FindGameObjectWithTag("Portal1");
        desabilitaPortal(); //desativar todos os portais no início do jogo
    }

    // Update is called once per frame
    void Update()
    {
        //Verifica se o jogador coletou a quantidade de pílulas de comida necessárias para ativar o Portal 0
        if(rotinaPlayer.foodPillAb_player>=quantPillsN1)
        {
            Debug.Log("Portal 0 ativado");
            portal0.SetActive(true);
        }
        //Verifica se o jogador coletou a quantidade de pílulas de comida necessárias para ativar o Portal 1
        if(rotinaPlayer.foodPillAb_player>=quantPillsN2)
        {
            Debug.Log("Portal 1 ativado");
            portal1.SetActive(true);
        }
    }

    //Método para desativar ambos os portais
    public void desabilitaPortal()
    {
        portal0.SetActive(false);
        portal1.SetActive(false);
    }
}
