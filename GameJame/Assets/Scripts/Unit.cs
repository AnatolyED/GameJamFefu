using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageble
{
    [Header("Move Points")]
    [SerializeField, Tooltip("Значение кол-ва очков хода")] private int _motionPoints;
    [SerializeField, Tooltip("Кол-во клеток хода за единицу очков действия")] private int _speed;

    [Space,Header("Health Parameters")]
    [SerializeField,Tooltip("Здоровье юнита")] private float _health;
    
    [Space,Header("Attack Parameters")]
    [SerializeField, Tooltip("Базовое значение урона")] private float _baseDamage;
    [SerializeField, Tooltip("Коэффициент увелечения урона")] private float _damageMultiplier;
    [SerializeField, Tooltip("Дальность атаки")] private int _range;
    
    [Space,Header("Protection parameters")]
    [SerializeField, Tooltip("Базовое значение защиты")] private float _baseArmor;
    [SerializeField, Tooltip("Коэффициент увеличения брони")] private float _armorMultiplier;

    [Space, Header("Information")]
    [SerializeField] private string _description;

    [Space, Header("GamePlay parametrs")]
    [SerializeField, Tooltip("Какому игроку пренадлежит юнит")] private PlayerMotion _unitMotion;
    [SerializeField, Tooltip("Какое действие выбранно")] private Action _unitAction;
    [SerializeField, Tooltip("Клетка на которой стоит")] private Cell _cell;
    [SerializeField, Tooltip("Разрешение на ход")] private bool _rightOfWay = false;

    //Контроллер анимации
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
        _anim.SetTrigger("AttackTrigger");
        int _points = 0; // Количество очков хода используемых для операции
        float _multiplier = Mathf.Pow(DamageMultiplier, _points);
        float _ultimateDamage = BaseDamage * _multiplier;
    }

    public virtual void RangeAttack()
    {
        _anim.SetTrigger("RangeAttackTrigger");
        int _points = 0; // Количество очков хода используемых для операции
        float _multiplier = Mathf.Pow(DamageMultiplier, _points);
        float _ultimateDamage = BaseDamage * _multiplier;
    }

    public virtual void Protection()
    {
        _anim.SetTrigger("BlockTrigger");
        int _points = 0; // Количество очков хода используемых для операции
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
