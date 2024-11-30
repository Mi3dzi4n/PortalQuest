using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class DiscordManager : MonoBehaviour
{
    Discord.Discord discord;

    private long sharedStartTime;

    public static DiscordManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (sharedStartTime == 0)
        {
            sharedStartTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        discord = new Discord.Discord(1311338738517016657, (ulong)Discord.CreateFlags.NoRequireDiscord);
        SceneManager.sceneLoaded += OnSceneLoaded;
        ChangeActivity(SceneManager.GetActiveScene().name);
    }

    void OnDisable()
    {
        discord.Dispose();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeActivity(scene.name);
    }

    public void ChangeActivity(string sceneName)
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity();
        switch (sceneName)
        {
            case "Main menu":
                activity = new Discord.Activity()
                {
                    State = "Browsing",
                    Details = "In Main Menu",
                    Assets = {
                        LargeImage = "portal_quest_2d_pixel_art_cyberpunk_logo",
                        LargeText = "Main Menu",
                        SmallImage = "small_menu_icon",
                        SmallText = "Menu"
                    },
                    Timestamps = {
                        Start = sharedStartTime
                    },
                };
                break;

            case "Level Selector":
                activity = new Discord.Activity()
                {
                    State = "Browsing",
                    Details = "In Level Selection",
                    Assets = {
                        LargeImage = "portal_quest_2d_pixel_art_cyberpunk_logo",
                        LargeText = "Level Selection",
                        SmallImage = "small_zone_icon",
                        SmallText = "Level"
                    },
                    Timestamps = {
                        Start = sharedStartTime
                    },
                };
                break;

            case "Level1": //Esclusion Zone
                activity = new Discord.Activity()
                {
                    State = "Playing Solo",
                    Details = "Exclusion Zone",
                    Assets = {
                        LargeImage = "portal_quest_2d_pixel_art_cyberpunk_logo",
                        LargeText = "Exclusion Zone",
                        SmallImage = "small_zone_icon",
                        SmallText = "Zone"
                    },
                    Timestamps = {
                        Start = DateTimeOffset.Now.ToUnixTimeSeconds()
                    },
                };
                break;
        }

        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log($"Activity updated for scene: {sceneName}");
            }
            else
            {
                Debug.LogError("Failed to update activity: " + res);
            }
        });
    }

    void Update()
    {

        discord.RunCallbacks();
    }
}
