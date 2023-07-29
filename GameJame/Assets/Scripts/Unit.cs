using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageble
{
    [Header("���� ����")]
    [SerializeField] private int _motionPoints;
    [Space,Header("��������� ��������")]
    [SerializeField] private float _health;
    [Space,Header("��������� �����")]
    [SerializeField] private int _baseDamage;
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private int _range;
    [Space,Header("��������� ������")]
    [SerializeField] private float _baseArmor;
    [SerializeField] private float _armorMultiplier;


    //��������
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

    //��������� ����� � ������
    public virtual void TakingDamage(float damage)
    {
        Health -= damage;
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
    
    //�����

    public virtual void Attack()
    {

    }
}
