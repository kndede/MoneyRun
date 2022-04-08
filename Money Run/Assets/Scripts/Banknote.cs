using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banknote : MonoBehaviour
{
    public bool isCollected = false;
    private void OnEnable()
    {
        isCollected = false;
    }
    public void CollectTheBanknote(bool _isCollected)
    {
        isCollected = _isCollected;
        if (_isCollected==true)
        {

            DestroyTheBanknote();
        }
    }

    void DestroyTheBanknote()
    {
        Destroy(this.gameObject);
    }
}
