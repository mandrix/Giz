using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AuthCtrl : MonoBehaviour
{
    struct UserAuth {
        public string username { get; set; }
        public int pin { get; set; }
    }

    private List<UserAuth> users;
    private UserAuth currentLoguedUser;

    // Start is called before the first frame update
    void Start()
    {
        users = new List<UserAuth> {
            new UserAuth { username = "Jorge Ramirez", pin = 1234 },
            new UserAuth { username = "Jeff Delgado", pin = 4321 }
        };

        currentLoguedUser = new UserAuth();
    }

    public bool CheckAuth(string pinString){
        int pin = Int32.Parse(pinString);
        bool auth = false;
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].pin == pin) {
                auth = true;
                currentLoguedUser = users[i];
                i = users.Count;
                
            }
            
        }
        return auth;
    }

    public string GetCurrentLogguedUserName() {
        return currentLoguedUser.username;
    }
}
