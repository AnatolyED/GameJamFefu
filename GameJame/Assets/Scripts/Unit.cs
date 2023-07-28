using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageble
{
    [Header("Параметры юнита")]
    [SerializeField]private int _health;

    [Header("Настройки атаки")]
    [SerializeField] private int _attakDamage;
    //Свойства
    public int Health
    {
        get { return _health; }
        set 
        { 
            _health = value;
            if (_health <= 0)
            {
                Death();
            }
        }
    }

    //Получение урона и смерть
    public virtual void TakingDamage(int damage)
    {
        Health -= damage;
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
    
    //Атака

    public virtual void Attack()
    {

    }
}
