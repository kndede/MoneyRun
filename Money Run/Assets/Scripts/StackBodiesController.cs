using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBodiesController : MonoBehaviour
{
    public Stack[] stackBodies;
    public int stackIndex = 0;
    private void Awake()
    {
        stackBodies = GetComponentsInChildren<Stack>();
        foreach (Stack item in stackBodies)
        {
            if (item.gameObject.activeSelf==true)
            {
                item.gameObject.SetActive(false);
            }
        }

        stackBodies[0].gameObject.SetActive(true);

        stackBodies[0].activeCollider = true;

        Debug.Log("Current stack index is " + (stackIndex));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Stack[] Bodies()
    {
        return stackBodies;
    }


    public void GetNextOneActive()
    {
        stackIndex++;

        stackBodies[stackIndex].gameObject.SetActive(true);

        stackBodies[stackIndex].activeCollider = true;

        


        Debug.Log("Current stack index is " + (stackIndex));
    }
    
}
