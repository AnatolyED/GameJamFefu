using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField, Header("Map configs")]
    private GameObject _gameMap;
    [SerializeField, Tooltip("Список координат объектов карты")]
    private List<Transform> _mapObjectsTransform = new List<Transform>();
    [SerializeField, Tooltip("Список префабов для генерации")]
    private List<GameObject> _prefabsBuildMap = new List<GameObject>();
    [SerializeField, Tooltip("Углы поворота для генерации")]
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
    private void Start()
    {
        Creator();
    }

    private void Creator()
    {
        for(int i = 0; i < _mapObjectsTransform.Count;i++)
        {
            int _randomPrefabNum = Random.Range(0, _prefabsBuildMap.Count - 1);
            int _randomRotation = Random.Range(0, _deegresOfRotation.Count - 1);
            GameObject _buildBlock = Instantiate(_prefabsBuildMap[_randomPrefabNum], _mapObjectsTransform[i].position,Quaternion.Euler(_deegresOfRotation[_randomRotation]),_gameMap.transform);
            Destroy(_mapObjectsTransform[i].gameObject);

        }
    }
}
