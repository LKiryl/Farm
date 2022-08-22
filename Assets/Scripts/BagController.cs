using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public int Value = 0;
    [SerializeField] private GameObject _bag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Value == 0)
        {
            _bag.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) // ����������� ����� , ���� � ��� ���� �������
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
