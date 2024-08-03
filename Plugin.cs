using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HideBetaRework.Patches;
using System.Reflection;

namespace HideBetaRework
{
    [BepInPlugin("redlaser42.MainMenuCleaner", "MainMenuCleaner", "1.0.0")]  
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource LogSource;

        private void Awake() //Awake() will run once when your plugin loads
        {
            LogSource = Logger;
            LogSource.LogInfo("MainMenuCleaner loaded!");

            new HideBetaReworkPatch().Enable();
            new HideVersionPatch().Enable();
            //new HideTopGlowPatch().Enable();
            new HideGameModePatch().Enable();

        }
    }
}
