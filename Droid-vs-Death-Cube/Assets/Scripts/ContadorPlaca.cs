using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorPlaca : MonoBehaviour
{
    private rotinaPlayer playerScript; // Referência ao script rotinaPlayer
    private TextMeshProUGUI texMesh; // responsável por exibir o texto do contador de placar
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();
        texMesh = GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(calculaPlacar), 0, 1f);
    }

    // Atualiza o texto do contador de placar com os valores atualizados
    private void calculaPlacar(){
        texMesh.text = "Food: "+(rotinaPlayer.foodPillAb_player).ToString("0")+" | Power: "+(rotinaPlayer.powerPillAb_player).ToString("0");
        
    }
}
