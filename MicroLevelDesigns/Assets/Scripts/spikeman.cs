using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeman : MonoBehaviour
{
   public SwitchManager switchManager;
   private New3dplayer _new3dplayer;
   new2denemy new2denemy;
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         
         switchManager.deathscreen();
         
      }else if (other.tag == "2d")
      {
         new2denemy = other.gameObject.GetComponent<new2denemy>();
         new2denemy.kill();
      }
      else if (other.tag == "3d")
         {
            _new3dplayer = other.gameObject.GetComponent<New3dplayer>();
            _new3dplayer.kill();
         }
      
      
   }
}
