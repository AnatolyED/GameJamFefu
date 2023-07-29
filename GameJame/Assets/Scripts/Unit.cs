using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageble
{
    [Header("Move Points")]
    [SerializeField] private int _motionPoints;
    [Space,Header("Health Parameters")]
    [SerializeField] private float _health;
    [Space,Header("Attack Parameters")]
    [SerializeField] private int _baseDamage;
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private int _range;
    [Space,Header("Protection parameters")]
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
