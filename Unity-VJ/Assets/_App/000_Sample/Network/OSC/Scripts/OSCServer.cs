using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class OSCServer : MonoBehaviour
{
    public IReadOnlyReactiveProperty<float> B1 => _b1;
    private readonly ReactiveProperty<float> _b1 = new FloatReactiveProperty();

    public IReadOnlyReactiveProperty<float> B2 => _b2;
    private readonly ReactiveProperty<float> _b2 = new FloatReactiveProperty();

    public IReadOnlyReactiveProperty<float> B3 => _b3;
    private readonly ReactiveProperty<float> _b3 = new FloatReactiveProperty();

    public IReadOnlyReactiveProperty<float> S1 => _s1;
    private readonly ReactiveProperty<float> _s1 = new FloatReactiveProperty();
    public void SetB1(float value)
    {
        _b1.Value = value;
        Debug.Log(_b1.Value);

    }
    public void SetB2(float value)
    {
        _b2.Value = value;
        Debug.Log(_b2.Value);

    }
    public void SetB3(float value)
    {
        _b3.Value = value;
        Debug.Log(_b3.Value);

    }

    public void SetS1(float value)
    {
        _s1.Value = value;
        Debug.Log(_s1.Value);

    }

}
