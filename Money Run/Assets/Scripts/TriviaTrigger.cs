using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TriviaTrigger : MonoBehaviour
{
    public TextMeshProUGUI question;
  //  public GameObject leftPanel;
  //  public GameObject rightPanel;


    private Collider myCol;
    private void Awake()
    {
        myCol=gameObject.GetComponent<Collider>();
    }
    int triggerCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (triggerCount==0)
        {
            question.gameObject.SetActive(true);
         //   leftPanel.SetActive(true);
          //  rightPanel.SetActive(true);

            Destroy(this.gameObject);
           
        }
        
            
        
    }
}
