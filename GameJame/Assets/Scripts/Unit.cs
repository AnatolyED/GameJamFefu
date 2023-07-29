using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageble
{
    [Header("Очки хода")]
    [SerializeField] private int _motionPoints;
    [Space,Header("Параметры здоровья")]
    [SerializeField] private float _health;
    [Space,Header("Параметры атаки")]
    [SerializeField] private int _baseDamage;
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private int _range;
    [Space,Header("Параметры защиты")]
    [SerializeField] private float _baseArmor;
    [SerializeField] private float _armorMultiplier;


    //Свойства
    public float Health
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
    public virtual void TakingDamage(float damage)
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
