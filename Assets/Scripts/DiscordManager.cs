using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiscordManager : MonoBehaviour
{
    Discord.Discord discord;

    void Start()
    {
        discord = new Discord.Discord(1311338738517016657, (ulong)Discord.CreateFlags.NoRequireDiscord);
        ChangeActivity();
    }

    void OnDisable()
    {
        discord.Dispose();
    }

    public void ChangeActivity()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity()
        {
            State = "Playing",
            Details = "Hello world!"
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            Debug.Log("Activity updated!");
        });
    }

    void Update()
    {
        discord.RunCallbacks();
    }
}
