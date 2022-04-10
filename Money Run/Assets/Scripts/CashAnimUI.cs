using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CashAnimUI : MonoBehaviour
{
    [SerializeField] private DOTweenAnimation dta;
    [SerializeField] CashAnimUI newCash;
    private void OnEnable()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instantiator()
    {

        Instantiate(newCash, new Vector3(0f, 0f, 0f), Quaternion.identity);

       // newCash.transform.position = new Vector3(0f, 425f, 0f);
    }

    void AnimateMe()
    {

    }
}
