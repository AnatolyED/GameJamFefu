using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Задел под мультиплеер
    /*
    [Header("User info")]
    [SerializeField] private string _nickName;
    [SerializeField] private int _id;
    */
    [SerializeField, Tooltip("Юниты игрока")] private List<GameObject> _units = new List<GameObject>(6);
    [SerializeField] private PlayerMotion _motion;

    public List<GameObject> GetUnitsPlayer
    {
        get { return _units; }
        set { _units = value; }
    }
    public PlayerMotion GetMotion
    {
        get { return _motion; }
    }
}
