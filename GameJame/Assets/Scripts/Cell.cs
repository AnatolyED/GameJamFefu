using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [Header("Colors and materials")]
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _baseColor;

    [Space,Header("Unit")]
    [SerializeField] private Unit _unitOnTheCell;

    public Unit GetUnit
    {
        get { return _unitOnTheCell; }
        set { _unitOnTheCell = value; }
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        if (tag == "StoneBuildBlock") _baseColor = _meshRenderer.materials[1].color;
        else _baseColor = _meshRenderer.material.color;
    }
    private void ChangeColor(Color color)
    {
        if (tag == "StoneBuildBlock") _meshRenderer.materials[1].color = color;
        else _meshRenderer.material.color = color;
    }

    private void OnMouseEnter()
    {
        ChangeColor(Color.green);
    }

    private void OnMouseExit()
    {
        ChangeColor(_baseColor);
    }
}