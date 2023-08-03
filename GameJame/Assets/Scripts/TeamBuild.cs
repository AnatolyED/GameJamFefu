using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamBuild : MonoBehaviour
{
    [Header("Champion and Units store option")]
    [SerializeField,Tooltip("Кол-во очков для покупки команды")] private int _scoreBuying= 100;
    [SerializeField, Tooltip("Список команды")] private List<GameObject> _unitsInventory = new List<GameObject>(4);
    

}
