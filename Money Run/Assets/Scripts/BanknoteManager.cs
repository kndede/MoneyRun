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
    public List<Banknote> collectedBaknotes;
    public void CollectedBanknoteList(Banknote _banknote)
    {
        collectedBaknotes.Add(_banknote);
    }
    public bool IsBanknoteCollected(Banknote _banknote)
    {
        if (collectedBaknotes.Count>0)
        {

            foreach (Banknote item in collectedBaknotes)
            {
                if (item == _banknote)
                {
                    return true;
                }
            }
        }
         return false;
        
    }
}
