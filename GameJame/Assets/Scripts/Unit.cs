using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageble
{
    [Header("��������� �����")]
    [SerializeField]private int _health;

    [Header("��������� �����")]
    [SerializeField] private int _attakDamage;
    //��������
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

    //��������� ����� � ������
    public virtual void TakingDamage(int damage)
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
