using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
        StartCoroutine(SelectObjectRaycast());
    }

    private IEnumerator SelectObjectRaycast()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit _hit;
            }
            yield return null;
        }
    }

}
