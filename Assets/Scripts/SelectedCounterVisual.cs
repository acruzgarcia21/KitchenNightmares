using System;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
   [SerializeField] private ClearCounter clearCounter;
   [SerializeField] private GameObject visualGameObject;
   
   // Singleton pattern
   private void Start()
   {
      Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
   }
   // Determines whether the user is near the counter and enables/disables selected counter visual
   private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
   {
      if (e.SelectedCounter == clearCounter)
      {
         Show();
      }
      else
      {
         Hide();
      }
   }

   private void Show()
   {
      visualGameObject.SetActive(true);
   }

   private void Hide()
   {
      visualGameObject.SetActive(false);
   }
}
