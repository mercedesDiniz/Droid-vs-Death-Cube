using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaNivel : MonoBehaviour
{
    private rotinaPlayer playerScript;
    public GameObject inimigos_nivel0;
    public GameObject inimigos_nivel1;
    public GameObject inimigos_nivel2;

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
                habilitaInimigosN0();
                desabilitaInimigosN1();
                desabilitaInimigosN2();
                break;
            case 1:
                desabilitaInimigosN0();
                habilitaInimigosN1();
                break;
            case 2:
                desabilitaInimigosN1();
                habilitaInimigosN2();
                break;
            default:
                desabilitaTodosInimigos();
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
