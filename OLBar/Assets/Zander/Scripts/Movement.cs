﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace OLBar
{
    public class Movement : NetworkBehaviour
    {
        int state;
        float count;
        float count2;
        //direction 
        float moveX;
        float moveY;
        private void Start()
        {
        }
        void Update()
        {

            if (!isLocalPlayer)
                return;
            User user = GetComponent<User>();
            //check if the player is drunk or not
            if (user.sanity > 60) {
                state = 1;
            }else {
                state = 0;
            }

            //switch player's movement behaviour based on the drunk state.
            switch (state) {
                // defult behaviour
                case 0:
                    moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 4.0f;
                    moveY = Input.GetAxis("Vertical") * Time.deltaTime * 4.0f;
                    transform.Translate(moveX, moveY, 0);
                    break;

                //drunk behaviour
                case 1:
                    count += Random.Range(0, 0.02f);
                    //add a random sin function on the X direction
                    moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 4.0f + 0.01f * Mathf.Sin(count);
                    count2 += Random.Range(0, 0.03f);
                    //add a random sin function on the Y direction
                    moveY = Input.GetAxis("Vertical") * Time.deltaTime * 4.0f + 0.01f * Mathf.Sin(count2);
                    
                    if (count > 10){
                        count = 0;
                        count2 = 0;}
                    transform.Translate(-moveX,-moveY, 0);
                    break;


            }
        }

    }
}