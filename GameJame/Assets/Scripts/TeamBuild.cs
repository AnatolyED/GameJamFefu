using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamBuild : MonoBehaviour
{
    [Header("Champion and Units store option")]
    [SerializeField,Tooltip("���-�� ����� ��� ������� �������")] private int _scoreBuying= 100;
    [SerializeField, Tooltip("������ �������")] private List<GameObject> _unitsInventory = new List<GameObject>(4);
    

}
