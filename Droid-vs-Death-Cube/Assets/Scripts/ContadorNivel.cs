using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorNivel : MonoBehaviour
{   
    private rotinaPlayer playerScript;
    private TextMeshProUGUI texMesh;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();
        texMesh = GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(calculaNivel), 0, 1f);   
    }

    private void calculaNivel(){
        texMesh.text = "Nivel: "+(rotinaPlayer.nivelAtualDoPlayer).ToString("0")+"/2";      
    }
}
