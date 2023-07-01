using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaNivel : MonoBehaviour
{
    private rotinaPlayer playerScript; // Referência ao script rotinaPlayer
    public GameObject inimigos_nivel0; // GameObject dos inimigos do nível 0
    public GameObject inimigos_nivel1; // GameObject dos inimigos do nível 1
    public GameObject inimigos_nivel2; // GameObject dos inimigos do nível 2

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();

        inimigos_nivel0 = GameObject.FindGameObjectWithTag("InimigosN0");
        inimigos_nivel1 = GameObject.FindGameObjectWithTag("InimigosN1");
        inimigos_nivel2 = GameObject.FindGameObjectWithTag("InimigosN2");

        desabilitaTodosInimigos();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Nivel: " + rotinaPlayer.nivelAtualDoPlayer);

        switch (rotinaPlayer.nivelAtualDoPlayer)
        {
            case 0:
                habilitaInimigosN0(); // Habilita os inimigos do nível 0
                desabilitaInimigosN1(); // Desabilita os inimigos do nível 1
                desabilitaInimigosN2(); // Desabilita os inimigos do nível 2
                break;
            case 1:
                desabilitaInimigosN0(); // Desabilita os inimigos do nível 0
                habilitaInimigosN1(); // Habilita os inimigos do nível 1
                break;
            case 2:
                desabilitaInimigosN1(); // Desabilita os inimigos do nível 1
                habilitaInimigosN2(); // Habilita os inimigos do nível 2
                break;
            default:
                desabilitaTodosInimigos(); // Desabilita todos os inimigos
                break;
        }
        
    }

    // Inimigos do Nivel 0:
    public void habilitaInimigosN0()
    {
        inimigos_nivel0.SetActive(true);
    }

    public void desabilitaInimigosN0()
    {
        inimigos_nivel0.SetActive(false);
    }

    // Inimigos do Nivel 1:
    public void habilitaInimigosN1()
    {
        inimigos_nivel1.SetActive(true);
    }

    public void desabilitaInimigosN1()
    {
        inimigos_nivel1.SetActive(false);
    }

    // Inimigos do Nivel 2:
    public void habilitaInimigosN2()
    {
        inimigos_nivel2.SetActive(true);
        rotinaPlayer.inimigosN2Iniciados = true;
    }

    public void desabilitaInimigosN2()
    {
        inimigos_nivel2.SetActive(false);
    }

    // Geral
    public void desabilitaTodosInimigos()
    {
        inimigos_nivel0.SetActive(false);
        inimigos_nivel1.SetActive(false);
        inimigos_nivel2.SetActive(false);
    }

}
