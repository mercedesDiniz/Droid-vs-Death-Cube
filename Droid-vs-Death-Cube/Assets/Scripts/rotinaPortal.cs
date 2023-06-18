using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaPortal : MonoBehaviour
{
    private rotinaPlayer playerScript;
    public GameObject portal0;
    public GameObject portal1;
    public static int quantPillsN1 = 20;
    public static int quantPillsN2 = 40;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();
        portal0 = GameObject.FindGameObjectWithTag("Portal0");
        portal1 = GameObject.FindGameObjectWithTag("Portal1");
        desabilitaPortal();
    }

    // Update is called once per frame
    void Update()
    {
        if(rotinaPlayer.foodPillAb_player>=quantPillsN1)
        {
            Debug.Log("Portal 0 ativado");
            portal0.SetActive(true);
        }
        if(rotinaPlayer.foodPillAb_player>=quantPillsN2)
        {
            Debug.Log("Portal 1 ativado");
            portal1.SetActive(true);
        }
    }

    public void desabilitaPortal()
    {
        portal0.SetActive(false);
        portal1.SetActive(false);
    }
}
