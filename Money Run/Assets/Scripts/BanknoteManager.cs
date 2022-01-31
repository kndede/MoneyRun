using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanknoteManager : MonoBehaviour
{
    public GameObject[] banknotes;
    private void Awake()
    {
        for (int i = 0; i < banknotes.Length; i++)
        {
            banknotes[i].gameObject.tag = "Cash";
        }
    }

    public void BanknoteCreator(Vector3 pos)
    {

    }
}
