using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlotGame : MonoBehaviour
{
    public Animator firstSlot;
    public Animator secondSlot;
    public Animator thirdSlot;

    private void Start()
    {
        EndGameEvents.ending.onEndGameTrigger += AnimateSlot;
    }

    void AnimateSlot()
    {

    }
}
