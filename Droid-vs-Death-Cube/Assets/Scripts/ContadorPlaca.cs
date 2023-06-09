using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorPlaca : MonoBehaviour
{
    private rotinaPlayer playerScript;

    private TextMeshProUGUI texMesh;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();
        texMesh = GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(calculaPlacar), 0, 1f);
    }

    private void calculaPlacar(){
        texMesh.text = (rotinaPlayer.foodPillAb_player).ToString("00");
    }
}
