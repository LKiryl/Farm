using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BarnController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject wheatPrefab;
    [SerializeField] private GameObject barn;
    [SerializeField] private GameObject scorePoint;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] public int score = 0;

    private GameObject _wheatPrefab;
    private GameObject _coin;
    
    [SerializeField] private float quantityCoins = 0;

    [SerializeField] private float speed;
    [SerializeField] private float speedCoin;
    

    void Update()
    {
        if(_wheatPrefab)             //Если пшеница есть в сумке , отпралвяем её в амбар и уничтожаем после + получаем монету                                           
        {
            _wheatPrefab.transform.position = Vector3.MoveTowards(_wheatPrefab.transform.position, barn.transform.position, speed * Time.deltaTime);

            if (_wheatPrefab.transform.position == barn.transform.position)
            {
                quantityCoins++;
                Destroy(_wheatPrefab);
                
            }
        }

        if (quantityCoins > 0)         //Проверяем есть ли монеты, если есть - создаём их и отправляем их в счёт

        {

            StartCoroutine(GettingCoin());
            

        }
        else
            StopCoroutine(GettingCoin());

        if(score >= 250)            //Если набрано нужное количество монет, включаем панель конца уровня
        {
            finishPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)    //При косании игроком места сдачи пшеницы, проверяем если она в сумке,если есть -  создаём её и отпраляем в амбар
    {
        if (other.CompareTag("Player"))
        {
            if (_player.GetComponent<BagController>()._value > 0)
            {
                StartCoroutine(PayWheat());
            }
            else
                StopCoroutine(PayWheat());
        }

        
    }

    IEnumerator PayWheat()
    {
        
        if (_wheatPrefab == null)
        {
            for(int i = 0; i < _player.GetComponent<BagController>()._value; _player.GetComponent<BagController>()._value--)
            {
                _wheatPrefab = Instantiate(wheatPrefab) as GameObject;
                _wheatPrefab.transform.position = _player.transform.TransformPoint(Vector3.up * 4f);
                yield return new WaitForSeconds(1f);
            }
            
            

        }
        

    }

    IEnumerator GettingCoin()
    {
        if (_coin == null)
        {
            
              _coin = Instantiate(coin) as GameObject;
                _coin.transform.position = barn.transform.TransformPoint(Vector3.up * 6f);
                
            
            
        }
        yield return new WaitForSeconds(1f);
        if (_coin)
        {
            _coin.transform.position = Vector3.MoveTowards(_coin.transform.position, scorePoint.transform.position, speedCoin * Time.deltaTime);
            if (_coin.transform.position == scorePoint.transform.position)
            {
                quantityCoins--;
                score += 15;
                _score.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<AudioSource>().Play();
                Destroy(_coin);


            }
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
