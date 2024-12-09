using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_UIManager : MonoBehaviour
{
    [SerializeField] RSO_EntityLife _entityLifeData;
    [SerializeField] RSE_EventChannel OnEntityLifeChange;
    [SerializeField] List<GameObject> _heartList;

    void Start()
    {
        OnEntityLifeChange.RegisterListener(UpdateHeart);
    }

    public void UpdateHeart()
    {
        if(_entityLifeData.entityLife <= _heartList.Count){
            for(int i = 0; i < _heartList.Count - _entityLifeData.entityLife ; i++ ){
                _heartList[i].SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        OnEntityLifeChange.UnregisterListener(UpdateHeart);
    }
}
