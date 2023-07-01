using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorNivel : MonoBehaviour
{   
    private rotinaPlayer playerScript; // Referência ao script rotinaPlayer
    private TextMeshProUGUI texMesh; // responsável por exibir o texto do contador de nível

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();
        texMesh = GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(calculaNivel), 0, 1f);   
    }

    // Atualiza o texto do contador de nível
    private void calculaNivel(){
        texMesh.text = "Nivel: "+(rotinaPlayer.nivelAtualDoPlayer).ToString("0")+"/2";      
    }
}
