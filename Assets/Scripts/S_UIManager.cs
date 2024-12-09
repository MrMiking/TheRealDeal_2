using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_UIManager : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] RSO_EntityLife _entityLifeData;
    [SerializeField] RSE_EventChannel OnEntityLifeChange;
    [SerializeField] TextMeshProUGUI _textlife;



    private void Awake()
    {
        _slider.maxValue = _entityLifeData.entityLife;
        _slider.minValue = 0;
        UpdateSliderBar();
    }
    void Start()
    {
        OnEntityLifeChange.RegisterListener(UpdateSliderBar);
    }

    void Update()
    {
        
    }

    public void UpdateSliderBar()
    {
        _slider.value = _entityLifeData.entityLife;
        _textlife.text = _entityLifeData.entityLife.ToString();

        if(_slider.value <= 0){
            ReloadScene();
        }

    }

    private void OnDestroy()
    {
        OnEntityLifeChange.UnregisterListener(UpdateSliderBar);
    }

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
