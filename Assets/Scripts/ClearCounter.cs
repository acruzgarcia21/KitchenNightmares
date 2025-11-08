using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSo kitchenObjectSo;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject _kitchenObject;
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
        }
    }
} 