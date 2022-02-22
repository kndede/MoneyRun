using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Deneme : MonoBehaviour
{


    public bool worked = false;


    public Animator mySlot;
    public int myRoll;
    public SlotGame sg;
    // Start is called before the first frame update
    private void Awake()
    {
        mySlot = GetComponent<Animator>();
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void PlayAnimation()
    {
        if (worked == false)
        {
            mySlot.SetTrigger("Slot" + myRoll);

            worked = true;
        }
    }
}
