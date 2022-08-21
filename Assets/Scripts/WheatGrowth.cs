using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatGrowth : MonoBehaviour
{
    [SerializeField] private GameObject wheat;
    [SerializeField] private GameObject wheat2;
    // Start is called before the first frame update


    private void FixedUpdate()
    {
        
        StartCoroutine(NeedWheatGrowth());
    }

    IEnumerator NeedWheatGrowth()        //Ќова€ по€вл€етс€, если стара€ полностью срезана 
    {
        if(!wheat.activeInHierarchy && !wheat2.activeInHierarchy)
        {
            yield return new WaitForSeconds(10f);
            wheat.SetActive(true);
            gameObject.SetActive(false);
        }

        
        
    }
}
