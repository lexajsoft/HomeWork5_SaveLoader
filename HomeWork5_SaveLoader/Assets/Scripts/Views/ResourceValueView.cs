using Model;
using UnityEngine;
using Views;

public class ResourceValueView : ViewBase
{
    [SerializeField] private TMPro.TextMeshProUGUI _valueText;
    private ResourceBase _resourceBase;
    public void SetResources(ResourceBase resourceBase)
    {
        if (_resourceBase != null)
        {
            _resourceBase.OnValueChanged -= OnValueChanged;
        }
        
        if(resourceBase == null)
            return;
        
        _resourceBase = resourceBase;
        _resourceBase.OnValueChanged += OnValueChanged;
        
        OnValueChanged(resourceBase.Value);
    }

    private void OnValueChanged(int obj)
    {
        _valueText.text = _resourceBase.GetName() + " : " + _resourceBase.Value;
    }
}