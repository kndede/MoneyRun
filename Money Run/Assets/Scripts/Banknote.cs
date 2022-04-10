using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banknote : MonoBehaviour
{
    public bool isCollected = false;
    BoxCollider myCol;
    MeshRenderer mesh;
    private void Awake()
    {
        myCol = GetComponent<BoxCollider>();
        mesh = GetComponent<MeshRenderer>();
    }
    private void OnEnable()
    {
        isCollected = false;
    }
    public void CollectTheBanknote(bool _isCollected)
    {
        isCollected = _isCollected;
        if (_isCollected==true)
        {
            mesh.enabled = false;
            myCol.enabled = false;
            this.gameObject.SetActive(false);
           // DestroyTheBanknote();
        }
    }

    void DestroyTheBanknote()
    {
        Destroy(this.gameObject);
    }
}
