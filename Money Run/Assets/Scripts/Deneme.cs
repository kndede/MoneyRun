using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Deneme : MonoBehaviour
{
    public Animator slot1;
    public Animator slot2;
    public Animator slot3;


    public SlotGame sg;

    public int rndSlot;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
        
        slot1.SetTrigger("Slot" + sg.slot1);
        slot2.SetTrigger("Slot" + sg.slot2);
        slot3.SetTrigger("Slot" + sg.slot3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
