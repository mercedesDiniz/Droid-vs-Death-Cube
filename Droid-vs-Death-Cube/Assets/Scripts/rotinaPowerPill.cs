using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaPowerPill : MonoBehaviour
{
    private rotinaPlayer playerScript;
    public float scaleSpeed = 0.8f; // Velocidade de redução da escala
    public float destroyDelay = 2f; // Tempo de espera antes de destruir o objeto após desaparecer

    private Vector3 initialScale;
    private bool isScaling = true;
    private bool absorvida = false;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (absorvida && isScaling)
        {
            // Reduz gradualmente a escala do objeto
            transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;

            // Verifica se o objeto ficou invisível
            if (transform.localScale.x <= 0f)
            {
                isScaling = false;
                Destroy(gameObject);
            }
        }
    }

    // Detecta colisão com o Player ou os Inimigos G
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            absorvida = true;
            rotinaPlayer.powerPillAb_player += 1;
        }
        if (collision.gameObject.CompareTag("InimigoG") || collision.gameObject.CompareTag("InimigoR"))
        {
            absorvida = true;
        }
    }
}
