using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class StackedCash : MonoBehaviour
{
    MeshRenderer myMesh;
    public bool isMeshActive=true;
    public int myIndex;
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

    
    public void AddTag()
    {
        gameObject.tag = "Cash";
    }
    void Update()
    {
        
    }

    public void DetachCash()
    {
        DisableMeshRenderer();

        //transform.DOJump(new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+4f),2f,1,2);
    }


}
