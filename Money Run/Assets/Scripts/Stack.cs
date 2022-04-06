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
        if (other.gameObject.tag=="Cash" && isStacked==false)
        {

            Destroy(other.gameObject);
            this.transform.localScale = new Vector3(1, 0.75f, 0.75f);
            sbc.ActiveTheStack();
             
        }
        else if (other.gameObject.tag == "SlidingObstacle")
        {
            SliderMovement thisSm=other.gameObject.GetComponent<SliderMovement>();

            Debug.Log("Stack " + myIndex + " has been hit.");
            if (this.isStacked == true)
            {
                Vector2 upperLeftCorner = thisSm.upperLeftCorner;
                Vector2 downRightCorner = thisSm.downRightCorner;
                sbc.DestroyStacks(this.myIndex,upperLeftCorner,downRightCorner);
            }
            

            //Throw the stack from collided area.

        }
        else if (other.gameObject.tag=="SawObstacle")
        {
            Saw thisSm = other.gameObject.GetComponent<Saw>();

            Debug.Log("Stack " + myIndex + " has been hit.");
            if (this.isStacked == true)
            {
                Vector2 upperLeftCorner = thisSm.upperLeftCorner;
                Vector2 downRightCorner = thisSm.downRightCorner;
                sbc.DestroyStacks(this.myIndex, upperLeftCorner, downRightCorner);
            }
        }
    }
    
   


}
