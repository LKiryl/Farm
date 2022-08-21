using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _bagScore;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private GameObject _barn;
    [SerializeField] private GameObject _bag;


  

    void Update()
    {
        _bagScore.text = $"{_bag.GetComponent<BagController>()._value} / 4";
        _score.text = $"{_barn.GetComponent<BarnController>().score}/250";

        
    }

   
}
