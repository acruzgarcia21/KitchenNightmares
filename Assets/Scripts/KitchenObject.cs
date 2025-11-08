using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSo kitchenObjectSo;

    private ClearCounter _clearCounter;

    public KitchenObjectSo GetKitchenObjectSo()
    {
        return kitchenObjectSo;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this._clearCounter != null)
        {
            this._clearCounter.ClearKitchenObject();
        }
        
        this._clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("Counter already has a kitchen object");
        }
        
        clearCounter.SetKitchenObject(this);
        // Update the position of the owned object
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return _clearCounter;
    }
    
}
