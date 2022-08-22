using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    [SerializeField] private int _value = 0;
    [SerializeField] private GameObject _bag;

    public int Value => _value;
    
    void Update()
    {
        if(_value == 0)
        {
            _bag.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) // Отображение сумки , если в ней есть пшеница
    {
        if (other.CompareTag("Wheat"))
        {


            if (_value < 4)
            {
                _value++;
                if (_value >= 1)
                {
                    _bag.SetActive(true);
                }
                Destroy(other.gameObject);
            }
        }
    }

   
}
