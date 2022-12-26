using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TransmissionGear
{
    [SerializeField] private int _gear;
    [SerializeField] private AnimationCurve _rpmCurve;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    public int Gear => _gear;
    public AnimationCurve RPMCurve => _rpmCurve;
    public float MinSpeed => _minSpeed;
    public float MaxSpeed => _maxSpeed; 
}
