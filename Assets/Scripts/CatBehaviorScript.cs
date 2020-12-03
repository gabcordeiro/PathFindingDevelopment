using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatBehaviorScript : MonoBehaviour
{
    [SerializeField]
    float raioDeDeteccao;
    [SerializeField]
    GameObject player;
    [SerializeField]
    float fatorDaAnimacao;
    [SerializeField]
    float distancia;
    bool estaMovendo = false;
    float velocidadeAnimacao;
    NavMeshAgent navMeshAgent;
    Animator animator;
    SphereCollider sphereCollider;
    void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        sphereCollider = GetComponent<SphereCollider>();
    }

  
    void Update()
    {
        CalcularPosicao();
        AnimacaoCat();
    }

    private void AnimacaoCat()
    {
        velocidadeAnimacao = navMeshAgent.velocity.magnitude * fatorDaAnimacao;
        animator.SetFloat("velocidadeMovimento", velocidadeAnimacao, 0f, Time.deltaTime);
    }

    private void CalcularPosicao()
    {
        Vector3 diferecaposicao = player.transform.position - transform.position;
        Vector3 displacement = transform.forward * distancia;
        if (diferecaposicao.sqrMagnitude < raioDeDeteccao)
        {
            estaMovendo = true;
            navMeshAgent.SetDestination(player.transform.position + displacement);
        }
        else if (diferecaposicao.sqrMagnitude <= 5)
        {
            navMeshAgent.Stop();
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("SEXO!");
        }
    }
}
