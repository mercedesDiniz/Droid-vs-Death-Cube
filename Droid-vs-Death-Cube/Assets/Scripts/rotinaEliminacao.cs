using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaEliminacao : MonoBehaviour
{
    //public GameObject inimigo;
    private rotinaPlayer playerScript;
    private Animator animator;
    private BoxCollider boxCollider;
    public float destroyDelay = 0.5f;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && rotinaPlayer.attack)
        {
            boxCollider.enabled = false;
            animator.SetBool("morreu", true);
            Invoke("DestroyEnemy", destroyDelay);
            // Aguarda o atraso antes de destruir o objeto inimigo
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
        rotinaPlayer.powerPillAb_player -=1; // usou a power pill p/ eliminar o inimigo
    }
}
