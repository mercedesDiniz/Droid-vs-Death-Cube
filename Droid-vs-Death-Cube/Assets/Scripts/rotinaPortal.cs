using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaPortal : MonoBehaviour
{
    private rotinaPlayer playerScript;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        portal.SetActive(false);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rotinaPlayer.foodPillAb_player>=5)
        {
            Debug.Log("Ativa portal");
            portal.SetActive(true);
        }
    }
}
