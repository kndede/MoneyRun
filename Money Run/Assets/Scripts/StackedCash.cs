using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class StackedCash : MonoBehaviour
{
    MeshRenderer myMesh;
    public bool isMeshActive=true;
    public int myIndex;

    public GameObject banknote;
    public ParticleSystem dollarBlast;

    public float secondsToWait= 1f;
    public float jumpPower;
    public float jumpDuration;
    private void Awake()
    {
        myMesh = GetComponent<MeshRenderer>();
        
    }
    void Start()
    {
    }
    public void DisableMeshRenderer()
    {
            isMeshActive = false;
            myMesh.enabled = false;
    }
    public void EnableMeshRenderer()
    {
        
            isMeshActive = true;
            myMesh.enabled = true;
        
    }

   
    void Update()
    {
        
    }

    public void DetachCash()
    {

        DisableMeshRenderer();

        //transform.DOJump(new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+4f),2f,1,2);
    }
    public void DetachCash(Vector2 upperLeftCorner, Vector2 downRightCorner)
    {

        DisableMeshRenderer();
        dollarBlast.Play();
        float x = upperLeftCorner.x;
        float maxz = upperLeftCorner.y;
        float minz = downRightCorner.y;
        float rndZ = Random.Range(minz, maxz);
        float rndX = Random.Range(x, -x);


        GameObject newObject = Instantiate(banknote, transform.position, Quaternion.identity);

        newObject.transform.DOScale(new Vector3(2, 2, 2), jumpDuration);
        newObject.transform.DORotate(new Vector3(0, 90f, 0), jumpDuration);

        newObject.transform.DOJump(new Vector3(rndX, 0.8f, rndZ), jumpPower, 1, jumpDuration).OnComplete(() => newObject.tag="Cash");
        
    }

   
    


}
