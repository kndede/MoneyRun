using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Deneme : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
        int random = Random.Range(1,5);
        animator.SetTrigger("Slot" + random);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
