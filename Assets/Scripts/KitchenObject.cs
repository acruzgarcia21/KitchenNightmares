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
        this._clearCounter = clearCounter;
    }

    public ClearCounter GetClearCounter()
    {
        return _clearCounter;
    }
    
}
