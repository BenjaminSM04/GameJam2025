using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialValue;
    public Vector2 newValue;
    public void OnAfterDeserialize()
    {
        initialValue = newValue;
    }
    public void OnBeforeSerialize() {
    }
}
