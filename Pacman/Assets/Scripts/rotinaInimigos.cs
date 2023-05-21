using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaInimigos : MonoBehaviour
{   
    private Animator animator;
    private GameObject player; // Referência para o objeto do jogador

    public float moveSpeed = 0.5f; // Velocidade de movimento do inimigo

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // Encontra o objeto do jogador na cena
        player = GameObject.FindGameObjectWithTag("Player");

        // Verifica se o objeto do jogador foi encontrado
        if (player == null)
        {
            Debug.LogError("Objeto do jogador não encontrado na cena!");
            animator.SetBool("andando", false);
            animator.SetBool("soco", false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
                // Calcula a direção do movimento em relação ao jogador
                Vector3 direction = player.transform.position - transform.position;
                direction.Normalize();

                // Move o inimigo na direção do jogador
                animator.SetBool("andando", true);
                animator.SetBool("soco", false);
                transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    // Detecta colisão com os Inimigos
    private void OnCollisionStay(Collision collision) {
        if(collision.gameObject.CompareTag("Player")) {
            animator.SetBool("andando", false);
            animator.SetBool("soco", true);
        }
    }
}
