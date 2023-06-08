using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaInimigosR : MonoBehaviour
{
    private Animator animator;
    private GameObject player; // Referência para o objeto do jogador
    private Rigidbody rb; // Componente Rigidbody do inimigo

    public float moveSpeed = 3.5f; // Velocidade de movimento do inimigo
    public float punchDistance = 1f; // Distância de aproximação antes de ativar a colisão

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Encontra o objeto do jogador na cena
        player = GameObject.FindGameObjectWithTag("Player");

        // Verifica se o objeto do jogador foi encontrado
        if (player == null) {
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
            // transform.position += direction * moveSpeed * Time.deltaTime;

            // Orienta o inimigo para olhar na direção do movimento
            transform.LookAt(player.transform);

            // Move o inimigo na direção do jogador usando o Rigidbody
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    // Detecta colisão com os Inimigos
    private void OnCollisionStay(Collision collision) {
        if(collision.gameObject.CompareTag("Player")) {
            // animator.SetBool("andando", false);
            // animator.SetBool("soco", true);

            // Calcula a distância entre o inimigo e o jogador
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= punchDistance) {
                animator.SetBool("andando", false);
                animator.SetBool("soco", true);
            }
        }
    }
}
