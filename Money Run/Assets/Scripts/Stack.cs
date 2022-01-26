using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public GameObject cashBody;
    public Stack[] cashBodies;
    public bool activeCollider;
    public bool isStacked;
    public MeshRenderer cashMr;

    private StackBodiesController sbc;
    private void Awake()
    {
        cashMr = cashBody.GetComponent<MeshRenderer>();
        sbc = GetComponentInParent<StackBodiesController>();
    }
    void Start()
    {

    }
    private void OnEnable()
    { 
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Cash")
        {
            Destroy(other.gameObject);

                if (cashMr.enabled==false)
                {
                    
                    cashMr.enabled=true;
                    isStacked = true;

                  sbc.GetNextOneActive();
                return;
                }
           
        }
    }
    
   


}
