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

    [Space, Header("Information")]
    [SerializeField] private string _description;

    [Space, Header("GamePlay parametrs")]
    [SerializeField, Tooltip("������ ������ ����������� ����")] private PlayerMotion _unitMotion;
    [SerializeField, Tooltip("����� �������� ��������")] private Action _unitAction;
    [SerializeField, Tooltip("������ �� ������� �����")] private Cell _cell;
    [SerializeField, Tooltip("���������� �� ���")] private bool _rightOfWay = false;

    //���������� ��������
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _unitAction = Action.None;
    }
    public bool RightOfAway
    {
        get { return _rightOfWay; }
        set { _rightOfWay = value; }
    }
    public PlayerMotion UnitTeam
    {
        get { return _unitMotion; }
        set { _unitMotion = value; }
    }
    public Action UnitAction
    {
        get { return _unitAction; }
        set { _unitAction = value; }
    }
    public Cell UnitCell
    {
        get { return _cell; }
        set { _cell = value; }
    }
    public int MotionPoints
    {
        get { return _motionPoints; }
        set{ _motionPoints = value; }
    }
    public float Health
    {
        get { return _health; }
        set 
        { 
            _health = value;
            if (_health <= 0)
            {
                _anim.SetTrigger("DeathTrigger");
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
        _anim.SetTrigger("AttackTrigger");
        int _points = 0; // ���������� ����� ���� ������������ ��� ��������
        float _multiplier = Mathf.Pow(DamageMultiplier, _points);
        float _ultimateDamage = BaseDamage * _multiplier;
    }

    public virtual void RangeAttack()
    {
        _anim.SetTrigger("RangeAttackTrigger");
        int _points = 0; // ���������� ����� ���� ������������ ��� ��������
        float _multiplier = Mathf.Pow(DamageMultiplier, _points);
        float _ultimateDamage = BaseDamage * _multiplier;
    }

    public virtual void Protection()
    {
        _anim.SetTrigger("BlockTrigger");
        int _points = 0; // ���������� ����� ���� ������������ ��� ��������
        float _multiplier = Mathf.Pow(DamageMultiplier, _points);
        float _ultimateProtection = BaseArmor * _multiplier;
    }

    public virtual void Skill()
    {
        _anim.SetTrigger("SkillTrigger");
    }

    public virtual void Walk()
    {
        _anim.SetTrigger("WalkTrigger");
    }
}
