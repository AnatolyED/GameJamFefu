using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageble
{
    [Header("Move Points")]
    [SerializeField, Tooltip("�������� ���-�� ����� ����")] private int _motionPoints;
    [SerializeField, Tooltip("���-�� ������ ���� �� ������� ����� ��������")] private int _speed;
    [Space,Header("Health Parameters")]
    [SerializeField,Tooltip("�������� �����")] private float _health;
    
    [Space,Header("Attack Parameters")]
    [SerializeField, Tooltip("������� �������� �����")] private float _baseDamage;
    [SerializeField, Tooltip("����������� ���������� �����")] private float _damageMultiplier;
    [SerializeField, Tooltip("��������� �����")] private int _range;
    
    [Space,Header("Protection parameters")]
    [SerializeField, Tooltip("������� �������� ������")] private float _baseArmor;
    [SerializeField, Tooltip("����������� ���������� �����")] private float _armorMultiplier;
    
    [Space,Header("Special parameters")]
    [SerializeField] private int _crit;


    //��������
    public int MotionPoints
    {
        get { return _motionPoints; }
        set
        {
            _motionPoints = value;
        }
    }
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
    public float BaseDamage
    {
        get { return _baseDamage; }
        set { _baseDamage = value; }
    }
    public float DamageMultiplier
    {
        get { return _damageMultiplier; }
        set { _damageMultiplier = value; }
    }
    public int Range
    {
        get { return _range; }
        set { _range = value; }
    }
    public float BaseArmor
    {
        get { return _baseArmor; }
        set { _baseArmor = value; }
    }
    public float ArmorMultiplier
    {
        get { return _armorMultiplier; }
        set { _armorMultiplier = value; }
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
        int _points = 0; // ���������� ����� ���� ������������ ��� ��������
        float _multiplier = Mathf.Pow(DamageMultiplier, _points);
        float _ultimateDamage = BaseDamage * _multiplier;
    }

    public virtual void Protection()
    {
        int _points = 0; // ���������� ����� ���� ������������ ��� ��������
        float _multiplier = Mathf.Pow(DamageMultiplier, _points);
        float _ultimateProtection = BaseArmor * _multiplier;
    }
}
