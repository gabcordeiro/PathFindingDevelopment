using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{

    
    
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    GameObject particula;
    [SerializeField]
    float fatorDaAnimacao;

    float velocidadeAnimacao;
    Vector3 destination;
    Animator animator;
    NavMeshAgent navMeshAgent;
    bool clicou = false;
    bool estaSeMovendo = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine("MovimentarCharacter");
            Instantiate(arrow, destination, Quaternion.identity);
            Instantiate(particula, destination, Quaternion.identity);
        }
        if (Input.GetMouseButton(1))
        {
            StartCoroutine("MovimentarCharacter");

        }
        if (navMeshAgent.velocity.sqrMagnitude > 0)
        {
            estaSeMovendo = true;
        }
        else
        {
            estaSeMovendo = false;
        }

        AtualizarAnimacao();

    }

    private void AtualizarAnimacao()
    {
    
        velocidadeAnimacao = navMeshAgent.velocity.magnitude * fatorDaAnimacao;

        //print(estaSeMovendo);

        animator.SetFloat("velocidadeMovimento", velocidadeAnimacao , 0f, Time.deltaTime);

        if (estaSeMovendo)
        {
            animator.speed = velocidadeAnimacao;
        }
        else
        {
            animator.speed = 1;
        }
       
    
    }

    IEnumerator MovimentarCharacter()
    {

        int layer_mask = LayerMask.GetMask("GroundLayer");

        Vector3 mouse = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hitData;
        
        if (Physics.Raycast(ray,out hitData, 1000f, layer_mask))
        {
           destination = hitData.point;
        }
        print(destination);
        Debug.DrawRay(mouse, destination);

        navMeshAgent.SetDestination(destination);
       
        yield return new WaitForSeconds(0.5f);
    }
}
