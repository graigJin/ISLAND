using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceSystem : Observer
{
    [SerializeField] private int woodAmount = 0;
    [SerializeField] private int stoneAmount = 0;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;

    public Texture hightLight;

    public int WoodAmount
    {
        get => woodAmount;
        set => woodAmount = value;
    }

    public int StoneAmount
    {
        get => stoneAmount;
        set => stoneAmount = value;
    }
    
    private Dictionary<Resource.ResourceType, int> _resources;
    private Dictionary<Resource.ResourceType, TextMeshProUGUI> _resourceTexts;
    private Texture _texture;
    private Resource _resource;

    void Start()
    {
        _resources = new Dictionary<Resource.ResourceType, int>
        {
            {Resource.ResourceType.Wood, WoodAmount}, 
            {Resource.ResourceType.Stone, StoneAmount}
        };
        
        _resourceTexts = new Dictionary<Resource.ResourceType, TextMeshProUGUI>
        {
            {Resource.ResourceType.Wood, woodText}, 
            {Resource.ResourceType.Stone, stoneText}
        };
        
        foreach (var resource in FindObjectsOfType<Resource>())
        {
            resource.RegisterObserver(this);
        }
    }
    
    public override void OnNotify(object value, NotificationType notificationType)
    {
        _resource = (Resource) value;
        Renderer r = _resource.ParentObject.GetComponent<Renderer>();
        
        if (notificationType == NotificationType.HarvestResource)
        {
            _resource.gameObject.GetComponentInChildren<Rotator>().IsRotating = true;
            StartCoroutine(GatherResource(_resource));
        }

        if (notificationType == NotificationType.Highlight)
        {
            _texture = r.material.mainTexture;
            r.material.SetTexture("_MainTex", hightLight);
        }
        
        if (notificationType == NotificationType.ReapplyTexture)
        {
            r.material.SetTexture("_MainTex", _texture);
        }
    }

    private IEnumerator GatherResource(Resource resource)
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1); 
        }
        
        _resources[resource.Type] += resource.Amount;
        _resourceTexts[resource.Type].text = _resources[resource.Type].ToString();

        Destroy(resource.ParentObject);
    }
}

public enum NotificationType
{
    Highlight,
    ReapplyTexture,
    HarvestResource
}
