using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField, Header("Map configs")]
    private GameObject _gameMap;
    [SerializeField, Tooltip("������ ��������� �������� ��� ������������ �� �����")]
    private List<Transform> _mapObjectsTransform = new List<Transform>();
    [SerializeField, Tooltip("������ ��������� �������� ��� ��������� ����������� ��������")]
    private List<Transform> _mapStopObjectsTransform = new List<Transform>(8);
    [SerializeField, Tooltip("������ �������� ��� ��������� ������ ������������")]
    private List<GameObject> _prefabsBuildMap = new List<GameObject>();
    [SerializeField, Tooltip("������ �������� ��� ��������� ����������� ������")]
    private List<GameObject> _prefabStopBuildMap = new List<GameObject>();
    [SerializeField, Tooltip("���� �������� ��� ��������� ������� ������")]
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
    [SerializeField, Tooltip("���� �������� ��� ��������� ����������� ������")]
    private List<Vector3> _deegresOfRotationStop = new List<Vector3>()
    {
        new Vector3(-90, 30, 0),
        new Vector3(-90, 90, 0),
        new Vector3(-90, 150, 0),
        new Vector3(-90, 210, 0),
        new Vector3(-90, 270, 0),
        new Vector3(-90, 330, 0)
    };
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
        for (int i = 0; i < _mapObjectsTransform.Count;i++)
        {
            _randomPrefabNum = Random.Range(0, _prefabsBuildMap.Count);
            _randomRotation = Random.Range(0, _deegresOfRotation.Count);

            GameObject _buildBlock = Instantiate(_prefabsBuildMap[_randomPrefabNum], _mapObjectsTransform[i].position, Quaternion.Euler(_deegresOfRotation[_randomRotation]), _gameMap.transform);
            Destroy(_mapObjectsTransform[i].gameObject);
        }
    }

    private void CreatorStopBlocks()
    {
        int _randomStopPrefab;
        int _randomRotationStop;
        for (int i = 0; i < _mapStopObjectsTransform.Count; i++) {
            _randomStopPrefab = BlockStopRandomSelection();
            _randomRotationStop = Random.Range(0, _deegresOfRotationStop.Count);

            if (_randomStopPrefab == 1 || _randomStopPrefab == 2)
            {
                GameObject _buildStopBlock = Instantiate(_prefabStopBuildMap[_randomStopPrefab], new Vector3(_mapStopObjectsTransform[i].position.x, _mapStopObjectsTransform[i].position.y - 0.78f, _mapStopObjectsTransform[i].position.z), Quaternion.Euler(_deegresOfRotationStop[_randomRotationStop]), _gameMap.transform);
                Destroy(_mapStopObjectsTransform[i].gameObject);
            }
            else if (_randomStopPrefab == 3)
            {
                GameObject _buildStopBlock = Instantiate(_prefabStopBuildMap[_randomStopPrefab], new Vector3(_mapStopObjectsTransform[i].position.x, _mapStopObjectsTransform[i].position.y, _mapStopObjectsTransform[i].position.z), Quaternion.Euler(_deegresOfRotationStop[_randomRotationStop]), _gameMap.transform);
                Destroy(_mapStopObjectsTransform[i].gameObject);
            }
        }
    }

    private int BlockStopRandomSelection()
    {
        int _randomNum = Random.Range(0, 100);
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
}
