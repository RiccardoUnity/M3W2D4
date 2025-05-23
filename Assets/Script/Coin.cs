using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    private uint _coins = 0;
    private List<Coin> _coinsList = new List<Coin>();
    public string tagPlayer = "Player";

    public void SetCoins(List<Coin> list)
    {
        _coinsList = list;
        _coins++;
    }
    
    void Start()
    {
        if (_coinsList.Count == 0)
        {
            _coinsList = transform.parent.GetComponentsInChildren<Coin>().ToList<Coin>();
            Debug.Log($"Trovate <color=#FFDE00>{_coinsList.Count}</color> monete");

            foreach (Coin coin in _coinsList)
            {
                if (coin != this)   //Non voglio sovrascrivere la lista dell'oggetto che cerca tutti gli altri
                {
                    coin.SetCoins(_coinsList);
                }
            }
        }

        _coins = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagPlayer))
        {
            Debug.Log($"Monete raccolte <color=#FFDE00>{++_coins}</color>");
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        _coinsList.Remove(this);

        if ( _coinsList.Count == 0 )
        {
            Debug.Log("HAI VINTO");
        }
        else
        {
            foreach (Coin coin in _coinsList)
            {
                coin.SetCoins(_coinsList);
            }
        }
    }
}
