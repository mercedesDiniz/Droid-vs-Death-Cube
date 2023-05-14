using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private CharacterController character; //referencia os componentes de controle do jogador
    private Animator animator; //
    private Vector3 inputs; //receber as entradas do teclado

    private float velocidade = 5f; //controla a velocidade do jogador

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>(); //atribuir o componente CharacterController em character
        animator = GetComponent<Animator>();
    }  

    // Update is called once per frame
    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")); //define os valores de entrada do teclado apenas para o eixo x e z
        character.Move(Vector3.down*Time.deltaTime); //simular gravidade

        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("soco", true);
            animator.SetBool("andando", false);
            inputs = Vector3.zero;
        }
        else if (inputs != Vector3.zero && Input.GetKey(KeyCode.Space)==false)
        {
            character.Move(inputs * Time.deltaTime * velocidade);
            animator.SetBool("andando", true);
            animator.SetBool("soco", false);
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime*10); //suavizar a rotação do personagem
        }
        else if (inputs == Vector3.zero && Input.GetKey(KeyCode.Space)==false)
        {
            animator.SetBool("andando", false);
            animator.SetBool("soco", false);
        }
    }
}
