using System;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
   // Singleton pattern
   private void Start()
   {
      Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
   }

   private void Player_OnSelectedCounterChanged(object sender, EventArgs e)
   {
      throw new NotImplementedException();
   }
}
