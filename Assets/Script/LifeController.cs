using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _health;

    private string _color = "36D128";

    void Awake()
    {
        _health = (_health == 0) ? 11 : _health;
    }

    public void TakeDamage(int damage) => SetHealth(-Mathf.Abs(damage), false);

    public void TakeHeal(int heal) => SetHealth(Mathf.Abs(heal), true);

    private void SetHealth(int amount, bool up)
    {
        _health = Mathf.Max(0, _health + amount);
        _color = (up) ? "36D128" : "C51E1E";


        if (_health == 0)
        {
            //Morto
            Debug.Log("Il giocatore è stato <color=#C51E1E>sconfitto</color> :(");   //Solo scritta rossa
            Destroy(this.gameObject);
        }
        else
        {
            //Vivo
            Debug.Log($"La vita del giocatore è di <color=#{_color}>{_health}</color>");   //Colore scritta che varia
        }
    }
}
