using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public bool activeCollider;
    public bool isStacked;
    public int myIndex;

    public GameObject thisCash;

    private StackBodiesController sbc;
    private StackedCash stackedCash;
    private void Awake()
    {
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

    public void DeactiveCollider()
    {
        this.isStacked = false;
        this.activeCollider = false;

        Debug.Log("Collider " + myIndex + " is deactived.");
        this.gameObject.SetActive(false);
    }
    public void ActiveCollider()
    {
        this.transform.localScale = new Vector3(1, 1f, 1f);
        this.gameObject.SetActive(true);
        this.activeCollider = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Cash")
        {
            this.transform.localScale = new Vector3(1, 0.5f, 0.5f);
            Destroy(other.gameObject);
            sbc.ActiveTheStack();
             
        }
        else if (other.gameObject.tag == "SlidingObstacle")
        {

            Debug.Log("Stack " + myIndex + " has been hit.");
            if (this.isStacked == true)
            {
                sbc.DestroyStacks(this.myIndex);
            }
            

            //Throw the stack from collided area.

        }
    }
    
   


}
