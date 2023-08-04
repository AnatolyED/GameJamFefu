using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGenerator : MonoBehaviour
{
    [SerializeField, Header("Map configs")]
    private GameObject _gameMap;
    [SerializeField, Tooltip("Список координат объектов для генерации передвижения по карте")]
    private List<Transform> _mapObjectsTransform = new List<Transform>();
    [SerializeField, Tooltip("Список координат объектов для передвижения по карте")]
    public List<Transform> _newMapObjectsTransform = new List<Transform>();
    [SerializeField, Tooltip("Список координат объектов для генерации блокирующих движение")]
    private List<Transform> _mapStopObjectsTransform = new List<Transform>(8);
    [SerializeField, Tooltip("Список префабов для генерации блоков передвижения")]
    private List<GameObject> _prefabsBuildMap = new List<GameObject>();
    [SerializeField, Tooltip("Список префабов для генерации блокирующих блоков")]
    private List<GameObject> _prefabStopBuildMap = new List<GameObject>();
    [SerializeField, Tooltip("Углы поворота для генерации обычных блоков")]
    private List<Vector3> _deegresOfRotation = new List<Vector3>(7) 
    {
        new Vector3(-90, 0, 0),
        new Vector3(-90, 60, 0),
        new Vector3(-90, 120, 0),
        new Vector3(-90, 180, 0),
        new Vector3(-90, 240, 0),
        new Vector3(-90, 300, 0),
        new Vector3(-90, 360, 0)
    };
    [SerializeField, Tooltip("Углы поворота для генерации блокирующих блоков")]
    private List<Vector3> _deegresOfRotationStop = new List<Vector3>()
    {
        new Vector3(-90, 30, 0),
        new Vector3(-90, 90, 0),
        new Vector3(-90, 150, 0),
        new Vector3(-90, 210, 0),
        new Vector3(-90, 270, 0),
        new Vector3(-90, 330, 0)
    };

    [SerializeField] private Player _first;
    [SerializeField] private Player _second;
    private void Start()
    {
        Creator();
    }
    private void Awake()
    {
        CreatorStopBlocks();
    }

    private void Creator()
    {
        int _randomPrefabNum;
        int _randomRotation;
        for (int i = 0; i < _mapObjectsTransform.Count; i++)
        {
            _randomPrefabNum = Random.Range(0, _prefabsBuildMap.Count);
            _randomRotation = Random.Range(0, _deegresOfRotation.Count);

            GameObject _buildBlock = Instantiate(_prefabsBuildMap[_randomPrefabNum], _mapObjectsTransform[i].position, Quaternion.Euler(_deegresOfRotation[_randomRotation]), _gameMap.transform);
            _newMapObjectsTransform.Add(_buildBlock.transform);
            Destroy(_mapObjectsTransform[i].gameObject);
        }
        _mapObjectsTransform.Clear();
        UnitsCreation();
    }

    private void CreatorStopBlocks()
    {
        int _randomStopPrefab;
        int _randomRotationStop;
        for (int i = 0; i < _mapStopObjectsTransform.Count; i++) {
            _randomStopPrefab = BlockRandomSelection(true);
            _randomRotationStop = Random.Range(0, _deegresOfRotationStop.Count);

            if (_randomStopPrefab == 1 || _randomStopPrefab == 2)
            {
                GameObject _buildStopBlock = Instantiate(
                    _prefabStopBuildMap[_randomStopPrefab],
                    new Vector3(_mapStopObjectsTransform[i].position.x,
                    _mapStopObjectsTransform[i].position.y - 0.78f,
                    _mapStopObjectsTransform[i].position.z),
                    Quaternion.Euler(_deegresOfRotationStop[_randomRotationStop]),
                    _gameMap.transform);
                Destroy(_mapStopObjectsTransform[i].gameObject);
            }
            else if (_randomStopPrefab == 3)
            {
                GameObject _buildStopBlock = Instantiate(_prefabStopBuildMap[_randomStopPrefab],
                    new Vector3(_mapStopObjectsTransform[i].position.x,
                    _mapStopObjectsTransform[i].position.y,
                    _mapStopObjectsTransform[i].position.z),
                    Quaternion.Euler(_deegresOfRotationStop[_randomRotationStop]),
                    _gameMap.transform);

                Destroy(_mapStopObjectsTransform[i].gameObject);
            }
        }
    }

    private int BlockRandomSelection(bool _stopBlocks)
    {
        int _randomNum = Random.Range(0, 100);
        if (_stopBlocks) {
            if (_randomNum < 25)
            {
                return 0;
            }
            else if (_randomNum >= 25 && _randomNum < 50)
            {
                return 1;
            }
            else if (_randomNum >= 50 && _randomNum < 75)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        else
        {
            if ((_randomNum < 10) || (_randomNum >= 30 && _randomNum < 40) || (_randomNum >= 55 && _randomNum < 65))
            {
                return 0;
            }
            else if ((_randomNum >= 15 && _randomNum < 25) || (_randomNum >= 45 && _randomNum < 55) || (_randomNum >= 85 && _randomNum < 95))
            {
                return 1;
            }
            else if (_randomNum >= 10 && _randomNum < 15)
            {
                return 2;
            }
            else if (_randomNum >= 25 && _randomNum < 30)
            {
                return 3;
            }
            else if (_randomNum >= 40 && _randomNum < 45)
            {
                return 4;
            }
            else if(_randomNum >= 65 && _randomNum < 70)
            {
                return 5;
            }
            else if (_randomNum >= 70 && _randomNum < 75)
            {
                return 6;
            }
            else if (_randomNum >= 75 && _randomNum < 80)
            {
                return 7;
            }
            else if(_randomNum >= 80 && _randomNum < 85)
            {
                return 8;
            }
            else
            {
                return 9;
            }
        }
    }
    private void UnitsCreation()
    {
        int[] _cellsNumFirstTeam = new int[] { 58, 59, 62, 68, 71, 51 };
        int[] _cellsNumSecondTeam = new int[] { 201, 133, 156, 134, 129 };

        for (int i = 0;i < _cellsNumFirstTeam.Length;i++)
        {
            _first._units[i].GetComponent<Unit>().UnitCell = _newMapObjectsTransform[_cellsNumFirstTeam[i]].GetComponent<Cell>();
            _first._units[i].GetComponent<Unit>().UnitCell.GetUnit = _first._units[i].GetComponent<Unit>();
            GameObject _unit = Instantiate(_first._units[i],_first._units[i].GetComponent<Unit>().UnitCell.transform.position, Quaternion.Euler(_first._units[i].GetComponent<Unit>().UnitCell.transform.rotation.x, 0 , _second._units[i].GetComponent<Unit>().UnitCell.gameObject.transform.rotation.z));
            _first._units[i] = _unit;
        }
        for (int i = 0; i < _cellsNumSecondTeam.Length; i++)
        {
            _second._units[i].GetComponent<Unit>().UnitCell = _newMapObjectsTransform[_cellsNumFirstTeam[i]].GetComponent<Cell>();
            _second._units[i].GetComponent<Unit>().UnitCell.GetUnit = _second._units[i].GetComponent<Unit>();
            GameObject _unit = Instantiate(_second._units[i], _second._units[i].GetComponent<Unit>().UnitCell.transform.position, Quaternion.Euler(_second._units[i].GetComponent<Unit>().UnitCell.transform.rotation.x, -180 , _second._units[i].GetComponent<Unit>().UnitCell.gameObject.transform.rotation.z));
            _second._units[i] = _unit;
        }
    }
}
