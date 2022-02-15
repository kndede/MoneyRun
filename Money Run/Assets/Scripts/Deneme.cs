using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Deneme : MonoBehaviour
{
    public Animator animator;


    public int rndSlot { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
        int random = Random.Range(1,5);
        rndSlot = random;
        animator.SetTrigger("Slot" + random);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
