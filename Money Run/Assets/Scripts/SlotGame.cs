using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlotGame : MonoBehaviour
{
    public Animator handleAnim;
    public Animator firstSlot;
    public Animator secondSlot;
    public Animator thirdSlot;


    public Dictionary<int, int> keyValuePairs;



    public int slot1;
    public int slot2;
    public int slot3;
    private void Start()
    {

        keyValuePairs = new Dictionary<int, int>() {
            {0,90 },
            {1,180 },
            {2,270 },
            {3,360 }
        };




        EndGameEvents.ending.onEndGameTrigger += AnimateSlot;
    }

    void AnimateSlot()
    {
        RandomizeSlots();
    }

    void RandomizeSlots()
    {
        var random = new System.Random();

        int first = random.Next(0, 4);
        int second = random.Next(0, 4);
        int third = random.Next(0, 4);


        slot1 = keyValuePairs[first];
        slot2 = keyValuePairs[second];
        slot3 = keyValuePairs[third];

    }
}
