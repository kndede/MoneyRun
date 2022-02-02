using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBodiesController : MonoBehaviour
{
    public Stack[] stackColliders;
    public StackedCash[] stackedCash;

    
   // public Stack[] activeStacks;
  //  public StackedCash[] stackedCashes;


    public int stackCount = 0;
    private void Awake()
    {
        stackColliders = GetComponentsInChildren<Stack>();

        int loopCount = 0;
        foreach (Stack item in stackColliders)
        {
            if (item.gameObject.activeSelf == true)
            {
                item.gameObject.SetActive(false);
                item.myIndex = loopCount;
                loopCount++;
            }
        }
        stackColliders[0].gameObject.SetActive(true);

        stackColliders[0].activeCollider = true;

        stackedCash = GetComponentsInChildren<StackedCash>();
        int loopCountForCash = 0;
        foreach (StackedCash item in stackedCash)
        {

            item.DisableMeshRenderer();
            item.myIndex = loopCountForCash;
            loopCountForCash++;

        }
        

        Debug.Log("Current stack count is " + (stackCount));
    }
   

    void GetNextColliderActive()
    {

       // stackColliders[stackCount].myIndex = stackCount;
        stackCount++;

        if (stackColliders.Length>stackCount)
        {
            stackColliders[stackCount].ActiveCollider();


        }

        Debug.Log("Current stack count is " + (stackCount));
    }

     void GetCashMeshActive()
    {
        stackColliders[stackCount].isStacked = true;
       // stackedCashes[stackIndex]=(stackedCash[stackIndex]);
       // stackedCash[stackCount].myIndex = stackCount;
        stackedCash[stackCount].EnableMeshRenderer();
    }

    public void ActiveTheStack()
    {

        GetCashMeshActive();
        GetNextColliderActive();
        
        
    }


    public void DestroyStacks(int index,Vector2 upperLeftCorner,Vector2 downRightCorner)
    {

        Debug.Log("Destack bounds are ");
        int forLoopCounter = 0;
        for (int i = index; i <= stackCount; i++)
        {
            if (i==stackCount)
            {
                stackColliders[i].isStacked = false;
                stackedCash[i].DetachCash();
                
            }
            else
            {

                stackColliders[i].isStacked = false;
                stackColliders[i + 1].DeactiveCollider();
                stackedCash[i].DetachCash(upperLeftCorner, downRightCorner);
                Debug.Log("Cash number  " + i + " is detached.");

                forLoopCounter++;
            }

        }

        stackCount -= forLoopCounter;
        if (stackCount<0)
        {
            stackCount = 0;
        }
        Debug.Log("After detaching, last stack count is " + stackCount + ". ");

    }

    public void CollectCash(int cashIndex)
    {
        stackColliders[cashIndex].isStacked = false;
        stackColliders[cashIndex+1].DeactiveCollider();
        stackedCash[cashIndex].DetachCash();
        stackCount--;
        Debug.Log("Cash number  " + cashIndex + " is detached and added to the bet");
    }

}
