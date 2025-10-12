using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BoolSword : ScriptableObject, ISerializationCallbackReceiver
{
    public bool Swordobteind;
    public bool newValue;
    public void OnAfterDeserialize()
    {
        Swordobteind = newValue;
    }
    public void OnBeforeSerialize()
    {
    }
}
