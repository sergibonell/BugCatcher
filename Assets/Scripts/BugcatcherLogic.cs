using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugcatcherLogic : MonoBehaviour, IWeapon
{
    Animator animator;
    ColliderCheck colliderCheck;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        colliderCheck = GetComponentInChildren<ColliderCheck>();
    }

    public void Action()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
            animator.Play("Swing");
    }

    public void CatchBug()
    {
        Destroy(colliderCheck.GetObject());
    }
}
