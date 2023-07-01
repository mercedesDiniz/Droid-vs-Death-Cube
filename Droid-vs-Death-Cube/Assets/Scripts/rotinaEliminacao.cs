using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaEliminacao : MonoBehaviour
{
    //public GameObject inimigo;
    private rotinaPlayer playerScript; // Referência ao script rotinaPlayer
    private Animator animator; // Compoenente responsável pela animação do inimigo
    private BoxCollider boxCollider; 
    private float destroyDelay = 3.0f; // Tempo de espera antes de destruir o objeto
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<rotinaPlayer>();
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Verifica a colisão 
    private void OnCollisionEnter(Collision collision)
    {
        //Verifica o player esta fazendo a ação de ataque
        if(collision.gameObject.CompareTag("Player") && rotinaPlayer.attack)
        {
            boxCollider.enabled = false;
            animator.SetBool("morreu", true);
            Invoke("DestroyEnemy", destroyDelay);
            // Aguarda o atraso antes de destruir o objeto inimigo
        }
    }
    
    // Destroi o objeto do inimigo
    private void DestroyEnemy()
    {
        Destroy(gameObject);
        rotinaPlayer.powerPillAb_player -=1; // usou a power pill p/ eliminar o inimigo
    }
}
