using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WheatController : MonoBehaviour
{
    [SerializeField] private Button _attackButton;
    [SerializeField] private GameObject wheat;
    [SerializeField] private GameObject wheatPrefab;
    
    


    private GameObject _wheatPrefab;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)  //Срезаем пшеницу, если попали по ней серпом
    {
        if (other.CompareTag("Sickle"))
        {
            _attackButton.onClick.AddListener(WheatOff);

            
        }
        
    }



    private void WheatOff()
    {
        
        gameObject.SetActive(false);
        wheat.SetActive(true);
        wheat.GetComponent<AudioSource>().Play();
        if (_wheatPrefab == null)
        {
            _wheatPrefab = Instantiate(wheatPrefab) as GameObject;
            _wheatPrefab.transform.position = transform.TransformPoint(Vector3.up* 0.1f);
            _wheatPrefab.GetComponent<Rigidbody>().position += Vector3.forward * 0.3f;
            

        }
        
            
    }
}
