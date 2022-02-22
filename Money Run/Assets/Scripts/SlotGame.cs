using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlotGame : MonoBehaviour
{
    public Animator handleAnim;
    public Deneme firstSlot;
    public Deneme secondSlot;
    public Deneme thirdSlot;


    public Dictionary<int, int> keyValuePairs;

    int slot1;
    int slot2;
    int slot3;
    private void Start()
    {

        keyValuePairs = new Dictionary<int, int>() {
            {0,5 },
            {1,9 },
            {2,7 },
            {3,3 }
        };




        EndGameEvents.ending.onEndGameTrigger += AnimateSlot;

    }

    void AnimateSlot()
    {
        RandomizeSlots();
        handleAnim.Play("anim");
        firstSlot.PlayAnimation();
        secondSlot.PlayAnimation();
        thirdSlot.PlayAnimation();
       // SlotWinCondition();
    }

    void RandomizeSlots()
    {
        var random = new System.Random();

        int first = random.Next(0, 4);
        int second = random.Next(0, 4);
        int third = random.Next(0, 4);


        firstSlot.myRoll = keyValuePairs[first]; 
        slot1= keyValuePairs[first];

        secondSlot.myRoll = keyValuePairs[second];
        slot2= keyValuePairs[second];

        thirdSlot.myRoll= keyValuePairs[third];
        slot3= keyValuePairs[third];

    }


    void SlotWinCondition()
    {
        if (slot1==slot2 && slot2==slot3)
        {
            //collector 
            Debug.Log("Kazandın!");
        }
    }
}
