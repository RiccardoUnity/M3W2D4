using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class PickUpChangeLife : MonoBehaviour
{
    private int _changeLife;
    private LifeController _lifeController;

    protected void SetChangeLife(int changeLife) => _changeLife = changeLife;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LifeController>(out _lifeController))
        {
            if (_changeLife < 0)
            {
                _lifeController.TakeDamage(_changeLife);
            }
            else
            {
                _lifeController.TakeHeal(_changeLife);
            }

            Destroy(this.gameObject);
        }
        else
        {
            Debug.LogWarning($"Non è presente il componente LifeController nel collision");
        }
    }
}
