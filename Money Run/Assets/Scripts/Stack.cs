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


    BoxCollider myCollider;
    private void Awake()
    {
        sbc = GetComponentInParent<StackBodiesController>();
        myCollider = GetComponent<BoxCollider>();

    }

    public void DeactiveCollider()
    {
        this.isStacked = false;
        this.activeCollider = false;
        SetColliderSize();
        Debug.Log("Collider " + myIndex + " is deactived.");
        this.gameObject.SetActive(false);
    }
    public void ActiveCollider()
    {
        this.transform.localScale = new Vector3(1, 1f, 1f);
        SetColliderSize();
        this.gameObject.SetActive(true);
        this.activeCollider = true;
    }
    public void ShrinkColliderSize()
    {

        myCollider.size = new Vector3(1f, 0.75f, 0.75f);
    }
    public void SetColliderSize()
    {

        myCollider.size = new Vector3(1, 1f, 1f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Cash" && other.gameObject.GetComponent<Banknote>()!=null)
        {
            other.gameObject.GetComponent<Banknote>().CollectTheBanknote(true);
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            //this.transform.localScale = new Vector3(1, 0.75f, 0.75f);
            ShrinkColliderSize();
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
