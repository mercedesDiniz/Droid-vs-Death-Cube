using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaPlayer : MonoBehaviour
{
    private CharacterController character; //referencia os componentes de controle do jogador
    private Animator animator; //
    private Vector3 inputs; //receber as entradas do teclado

    private float velocidade = 5f; //controla a velocidade do jogador

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
        inputs.Set(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")); //define os valores de entrada do teclado apenas para o eixo x e z
        character.Move(Vector3.down*Time.deltaTime); //simular gravidade

        var forward = myCamera.TransformDirection(Vector3.forward);
        forward.y = 0;

        var right = myCamera.TransformDirection(Vector3.right);

        Vector3 direcao = inputs.x * right + inputs.z * forward;

        if (inputs != Vector3.zero && direcao.magnitude >0.1f)
        {
            Quaternion freeRotation = Quaternion.LookRotation(direcao.normalized, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.eulerAngles.x, freeRotation.eulerAngles.y, transform.eulerAngles.z)), 10 * Time.deltaTime);
        }



        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("soco", true);
            animator.SetBool("andando", false);
            inputs = Vector3.zero;
        }
        else if (inputs != Vector3.zero && Input.GetKey(KeyCode.Space)==false)
        {
            character.Move(transform.forward * inputs.magnitude* Time.deltaTime * velocidade);
            animator.SetBool("andando", true);
            animator.SetBool("soco", false);
            //transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime*10); //suavizar a rotação do personagem
        }
        else if (inputs == Vector3.zero && Input.GetKey(KeyCode.Space)==false)
        {
            animator.SetBool("andando", false);
            animator.SetBool("soco", false);
        }
    }

    // Detecta colisão com os Inimigos
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("InimigoR") || collision.gameObject.CompareTag("InimigoG") || collision.gameObject.CompareTag("InimigoB")){
            Destroy(gameObject);
        }
    }

}


