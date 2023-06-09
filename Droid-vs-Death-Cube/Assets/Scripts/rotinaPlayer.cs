using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotinaPlayer : MonoBehaviour
{
    [SerializeField] private string telaGamerOver;
    [SerializeField] private string telaVictory;
    
    private CharacterController character; //referencia os componentes de controle do jogador
    private Animator animator; //
    private Vector3 inputs; //receber as entradas do teclado

    private float velocidade = 7.5f; //controla a velocidade do jogador
    public float destroyDelay = 0.5f; // Tempo de espera antes de destruir o objeto inimigo
    public static int foodPillAb_player = 0;
    public static int powerPillAb_player = 0;


    private Transform myCamera;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>(); //atribuir o componente CharacterController em character
        animator = GetComponent<Animator>();
        myCamera = Camera.main.transform;
    }  

    // Update is called once per frame
    void Update()
    {   
         Debug.Log(foodPillAb_player);
        //Debug.Log(powerPillAb_player);

        inputs.Set(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")); //define os valores de entrada do teclado apenas para o eixo x e z
        character.Move(Vector3.down*Time.deltaTime); //simular gravidade

        var forward = myCamera.TransformDirection(Vector3.forward);
        forward.y = 0;

        var right = myCamera.TransformDirection(Vector3.right);

        Vector3 direcao = inputs.x * right + inputs.z * forward;

        if (inputs != Vector3.zero && direcao.magnitude >0.1f && animator.GetBool("morreu") == false)
        {
            Quaternion freeRotation = Quaternion.LookRotation(direcao.normalized, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.eulerAngles.x, freeRotation.eulerAngles.y, transform.eulerAngles.z)), 10 * Time.deltaTime);
        }



        if(Input.GetKey(KeyCode.Space) && animator.GetBool("morreu") == false)
        {
            animator.SetBool("soco", true);
            animator.SetBool("andando", false);
            inputs = Vector3.zero;
        }
        else if (inputs != Vector3.zero && Input.GetKey(KeyCode.Space)==false && animator.GetBool("morreu") == false)
        {
            character.Move(transform.forward * inputs.magnitude* Time.deltaTime * velocidade);
            animator.SetBool("andando", true);
            animator.SetBool("soco", false);
            //transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime*10); //suavizar a rotação do personagem
        }
        else if (inputs == Vector3.zero && Input.GetKey(KeyCode.Space)==false && animator.GetBool("morreu") == false)
        {
            animator.SetBool("andando", false);
            animator.SetBool("soco", false);
        }
    }

    // Detecta colisão com os Inimigos
    private void OnCollisionStay(Collision collision) {
        if(collision.gameObject.CompareTag("InimigoR") || collision.gameObject.CompareTag("InimigoG") || collision.gameObject.CompareTag("InimigoB")){
            animator.SetBool("morreu", true);
            // Aguarda o atraso antes de destruir o objeto inimigo
            Invoke("DestroyEnemy", destroyDelay);
        }
    }

    // Detecta colisão com o Portal
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Portal0"))
        {
            // Definir a posição de destino do teleport
            Vector3 destino = new Vector3(0f, 40f, 0f); // Substitua pelos valores desejados para a posição de destino

            // Teleportar o jogador para a posição de destino
            //character.enabled = false; // Desabilitar o CharacterController temporariamente para mover o jogador diretamente
            transform.position = destino;
            //character.enabled = true; // Reabilitar o CharacterController após o teleport
        }
        if (collision.gameObject.CompareTag("Portal1"))
        {
            // Definir a posição de destino do teleport
            Vector3 destino = new Vector3(0f, 80f, 0f); // Substitua pelos valores desejados para a posição de destino

            // Teleportar o jogador para a posição de destino
            //character.enabled = false; // Desabilitar o CharacterController temporariamente para mover o jogador diretamente
            transform.position = destino;
            //character.enabled = true; // Reabilitar o CharacterController após o teleport
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(telaGamerOver);
    }

}


