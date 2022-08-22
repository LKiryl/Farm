using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    
    [SerializeField] private GameObject _bag;
    [SerializeField] private GameObject _barn;

    public int Value = 0;
    
    void FixedUpdate()
    {
        if(Value == 0)
        {
            _bag.SetActive(false);
        }

        
       
    }

    private void OnTriggerEnter(Collider other) // Отображение сумки , если в ней есть пшеница
    {
        if (other.CompareTag("Wheat"))
        {


            if (Value < 4)
            {
                Value++;
                if (Value >= 1)
                {
                    _bag.SetActive(true);
                }
                Destroy(other.gameObject);
            }
        }
    }

   
}
