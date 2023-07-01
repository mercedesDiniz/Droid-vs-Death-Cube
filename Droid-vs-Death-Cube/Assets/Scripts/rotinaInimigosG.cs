using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotinaInimigosG : MonoBehaviour
{   
    private Animator animator;
    private List<GameObject> foodPills; // Lista de objetos de Food Pill
    private Rigidbody rb; // Componente Rigidbody do inimigo

    public float moveSpeed = 5f; // Velocidade de movimento do inimigo
    public float punchDistance = 1f; // Distância de aproximação antes de ativar a colisão

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Encontra todos os objetos de Food Pill na cena
        GameObject[] foodPillArray = GameObject.FindGameObjectsWithTag("foodPill");

        // Adiciona as Food Pills encontradas à lista
        foodPills = new List<GameObject>(foodPillArray);

        // Verifica se pelo menos uma Food Pill foi encontrada
        if (foodPills == null || foodPills.Count == 0)
        {
            Debug.LogError("Nenhuma Food Pill encontrada na cena!");
            animator.SetBool("andando", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Encontra todos os objetos de Food Pill na cena
        GameObject[] foodPillArray = GameObject.FindGameObjectsWithTag("foodPill");

        // Adiciona as Food Pills encontradas à lista
        foodPills = new List<GameObject>(foodPillArray);

        if (foodPills != null && foodPills.Count > 0)
        {
            GameObject closestFoodPill = null;
            float closestDistance = Mathf.Infinity;

            // Encontra a Food Pill mais próxima do inimigo
            foreach (GameObject pill in foodPills)
            {
                float distance = Vector3.Distance(transform.position, pill.transform.position);

                if (distance < closestDistance)
                {
                    closestFoodPill = pill;
                    closestDistance = distance;
                }
            }

            if (closestFoodPill != null)
            {
                Vector3 direction = closestFoodPill.transform.position - transform.position;
                direction.Normalize();

                // Faz o inimigo olhar na direção da Food Pill mais próxima
                transform.LookAt(closestFoodPill.transform);
                animator.SetBool("andando", true);
                // Move o inimigo em direção à Food Pill
                rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);

                // Verifica se chegou perto o suficiente da Food Pill
                float distance = Vector3.Distance(transform.position, closestFoodPill.transform.position);
                if (distance <= punchDistance)
                {
                    // Remove a Food Pill consumida da lista
                    foodPills.Remove(closestFoodPill);

                    animator.SetBool("andando", false);
                }
            }
        }
    }
}
