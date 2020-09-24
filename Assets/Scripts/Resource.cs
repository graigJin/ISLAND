using UnityEngine;

public class Resource : Subject
{
    public enum ResourceType
    {
        Wood,
        Stone
    }

    public ResourceType Type;
    public int Amount;
    public GameObject ParentObject;

    // Start is called before the first frame update
    void Start()
    {
        ParentObject = gameObject;
    }
    
    private void OnMouseEnter()
    {
        Notify(this, NotificationType.Highlight);
    }
    
    private void OnMouseExit()
    {
        Notify(this, NotificationType.ReapplyTexture);
    }

    private void OnMouseDown()
    {
        Notify(this, NotificationType.HarvestResource);
    }
}
