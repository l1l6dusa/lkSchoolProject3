using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxEffect : MonoBehaviour
{
    [SerializeField] private ParralaxContainer[] _backgrounds;
    
    private Vector3 _lastCameraPos;
    
    void Start()
    {
        _lastCameraPos = transform.position;
    }

    void LateUpdate()
    {
        var deltaPos = transform.position - _lastCameraPos;
        for (int i = 0; i<_backgrounds.Length; i++)
        {
            _backgrounds[i].transform.position += new Vector3(_backgrounds[i].parralaxMultiplier.x* deltaPos.x, _backgrounds[i].parralaxMultiplier.y * deltaPos.y, 0);
        }

        _lastCameraPos = transform.position;
    }
    
    [Serializable]
    public class ParralaxContainer
    {
        
        public Transform transform;
        
        public Vector2 parralaxMultiplier;
    }
}

