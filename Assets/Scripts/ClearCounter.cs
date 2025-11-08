using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSo kitchenObjectSo;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject _kitchenObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (_kitchenObject != null)
            {
                _kitchenObject.SetClearCounter(secondClearCounter);
                Debug.Log(_kitchenObject.GetClearCounter());
            }
        }
    }
    public void Interact()
    {
        // This prevents spawning in multiple items on interaction with counter
        if (_kitchenObject == null)
        { 
            // Spawns in kitchen object on top of counter using the empty object that was created on top
            // of the counter prefab
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;
            
            // Stores kitchen object when null, if not null, there won't be a need to store it when occupied
            _kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            _kitchenObject.SetClearCounter(this);
        }
        else
        {
            Debug.Log(_kitchenObject.GetClearCounter());
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this._kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return _kitchenObject;
    }

    public void ClearKitchenObject()
    {
        _kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return _kitchenObject != null;
    }
} 