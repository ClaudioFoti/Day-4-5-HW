using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class RobotView : MonoBehaviour
{
    private RobotController _controller;

    private List<MeshRenderer> _meshRenderers;
    private Material _material;

    private List<GameObject> _robotParts;
    private readonly string[] _robotPartsNames = {"Torso", "Head", "LeftArm", "LeftHand", "RightArm", "RightHand", "LeftLeg", "LeftFoot", "RightLeg", "RightFoot"};
    
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderers = new List<MeshRenderer>();
        _robotParts = new List<GameObject>();
        
        _controller = new RobotController(RobotModel.RobotState.Human);
        
        _material = new Material(Shader.Find("Standard"));
        _material.color = _controller.Colour;
        
        foreach (string partName in _robotPartsNames)
        {
            GameObject part = GameObject.Find(partName);

            if (part is not null)
            {
                MeshRenderer meshRenderer = part.GetComponent<MeshRenderer>();
                meshRenderer.material = _material;
                
                _robotParts.Add(part);
                _meshRenderers.Add(meshRenderer);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _controller.Human();
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            _controller.Car();
        }
        
        if (Input.GetKey(KeyCode.Alpha3))
        {
            _controller.Airplane();
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _controller.Next();
        }
        
        UpdateRobot();
    }

    void UpdateRobot()
    {
        ChangeColors();
        ChangePositions();
        ChangeRotations();
    }

    void ChangePositions()
    {
        Vector3[] positions = _controller.GetPositions();
        
        int i = 0;
        foreach (GameObject part in _robotParts)
        {
            Vector3 position = positions[i];
            part.transform.localPosition = position;
            i++;
        }
    }
    
    void ChangeRotations()
    {
        Vector3[] rotations = _controller.GetRotations();
        
        int i = 0;
        foreach (GameObject part in _robotParts)
        {
            Vector3 rotation = rotations[i];
            part.transform.localEulerAngles = rotation;
            i++;
        }
    }

    void ChangeColors()
    {
        _material.color = _controller.Colour;
        
        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            meshRenderer.material = _material;
        }
    }
}
