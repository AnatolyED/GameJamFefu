using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _firstPlayer;
    [SerializeField] private Player _secondPlayer;
    [SerializeField] private PlayerMotion _gameMotion;
    [SerializeField] private Camera _camera;

    [Header("Camera actions")]
    [SerializeField] Transform _firstPos;
    [SerializeField] Transform _secondPos;


    [Space]
    [SerializeField]private Transform _firstSelectedObject;
    [SerializeField]private Transform _secondSelectedObject;
    [SerializeField]private Action _action;
    [SerializeField]privat
    public Player FirstPlayer
    {
        get { return _firstPlayer; }
    }
    public Player SecondPlayer
    {
        get { return _secondPlayer; }
    }
    public PlayerMotion GameMotion
    {
        get { return _gameMotion; }
        set { _gameMotion = value; }
    }
    private void Start()
    {
        _action = Action.None;
        _firstSelectedObject = null;
        _secondPlayer = null;
        _camera = Camera.main;
        _gameMotion = PlayerMotion.First;
        StartCoroutine(SelectObjectRaycast());
    }
    private IEnumerator SelectObjectRaycast()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.layer == 6 || hit.collider.gameObject.layer == 3)
                    {
                        if (hit.collider.gameObject.layer == 6) 
                        {
                            if (hit.collider.gameObject.GetComponent<Cell>().GetUnit == null && _action == Action.Move)
                            {
                                if (_firstSelectedObject == null) 
                                {
                                    Debug.Log("Выбери юнита для хода!");
                                }
                                else
                                {
                                    _secondSelectedObject = hit.collider.gameObject.transform;
                                }
                            }
                            else if (hit.collider.gameObject.GetComponent<Cell>().GetUnit != null && (_action == Action.Attack || _action == Action.RangeAttack || _action == Action.Skill))
                            {
                                _secondSelectedObject = hit.collider.gameObject.transform;
                                Activity(_action,_firstSelectedObject.gameObject,);
                            }
                        }
                        else if (hit.collider.gameObject.layer == 3 && hit.collider.gameObject.GetComponent<Unit>().UnitTeam == GameMotion && hit.collider.gameObject.GetComponent<Unit>().RightOfAway == true)
                        {
                            if (_firstSelectedObject == null || (_firstSelectedObject == hit.collider.gameObject.transform))
                            {
                                _firstSelectedObject = hit.collider.gameObject.transform;
                            }
                            else
                            {
                                Debug.Log("Уже выбран, ходи давай");
                            }
                        }
                        
                    }
                    else
                    {
                        Debug.Log("ну явно же, что выбрал что-то не то");
                    }
                }
            }
            yield return null;
        }
    }

    private void Activity(Action action,GameObject _unit,int _scoreActivity)
    {
        switch (action)
        {
            case Action.Attack:
                _firstSelectedObject.GetComponent<Unit>().Attack();
                break;
            case Action.RangeAttack:
                _firstSelectedObject.GetComponent<Unit>().RangeAttack();
                break;
            case Action.Block:
                _firstSelectedObject.GetComponent<Unit>().Protection();
                break;
            case Action.Skill:
                _firstSelectedObject.GetComponent<Unit>().Skill();
                break;
            case Action.Move:
                _firstSelectedObject.GetComponent<Unit>().Walk();
                break;
            default:
                break;
        }
    }
}
