using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Analytics;
using Firebase.Unity.Editor;




public class Database
{
    //create an instance of the Firebase app that can be referenced at any time
    public Firebase.FirebaseApp app;
    public DatabaseReference users = FirebaseDatabase.DefaultInstance.GetReference("users");
    public DatabaseReference maps = FirebaseDatabase.DefaultInstance.GetReference("maps");

   

    //in order for a player to connect to the database, make sure this step happens first to set up the database instance
    public void CheckForDependencies()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            //Checks to make sure Database is ready to go
            if (dependencyStatus == DependencyStatus.Available)
            {
                //Setting up the Default Instance for the Database
                app = FirebaseApp.DefaultInstance;
                app.SetEditorDatabaseUrl("https://monster-defender.firebaseio.com/");
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

                Test();

               
            }
            else
            {
                Debug.LogError(string.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public void Test()
    {
        users.GetValueAsync().ContinueWith(task =>
                {
            if (task.IsFaulted)
            {
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                Debug.Log(snapshot.Key);           
            }

        });
    }


    public void UploadMap(string mapName)
    {
       
        //maps.Child(mapName).SetValueAsync(JsonUtility.ToJson(info));

        maps.Child(mapName).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                Debug.Log(snapshot.Value);
            }

        });

    }
}
