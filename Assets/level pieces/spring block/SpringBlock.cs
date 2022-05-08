using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBlock : MonoBehaviour
{
    [SerializeField] private Rigidbody headRigidbody;
    [SerializeField] private SkinnedMeshRenderer springMeshRend;
    [SerializeField] private Animator animator;

    [SerializeField] private float timeOffset = 0;
    [SerializeField] private float closedSeconds = 1;
    [SerializeField] private float openSeconds = 1;
    [SerializeField] private float springMult = 1;

    private void OnValidate()
    {
        headRigidbody.isKinematic = true;
        animator.animatePhysics = true;
    }

    private void Awake()
    {
        StartCoroutine(InitialWait());
        animator.SetFloat("speed", springMult);
    }

    IEnumerator InitialWait()
    {
        yield return new WaitForSeconds(timeOffset);
        StartCoroutine(Cycle());
    }

    IEnumerator Cycle()
    {
        animator.SetBool("open", true);
        yield return new WaitForSeconds(openSeconds);
        animator.SetBool("open", false);
        yield return new WaitForSeconds(closedSeconds);
        StartCoroutine(Cycle());
    }
}
