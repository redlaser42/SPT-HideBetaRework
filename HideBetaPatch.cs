using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFT;
using System.Runtime.CompilerServices;
using EFT.UI;
using UnityEngine;
using SPT.Core.Patches;
using SPT.Reflection.Patching;

//this example patch will limit the number of jumps you can do to 3, and log whether or not your jump was successful

namespace HideBetaRework.Patches
{
    internal class HideBetaReworkPatch : ModulePatch //we must inherit ModulePatch for our patch to work.
    {

        private void HideVersionNumber()
        {


        }

        private void HideBetaWarning()
        { 

        }



        protected override MethodBase GetTargetMethod()
        {
            //methods are patched by targeting both their class name and the name of the method itself.
            //the example in this patch is the Jump() method in the Player class
            return AccessTools.Method(typeof(MenuScreen), nameof(MenuScreen.method_3));
        }


        [PatchPrefix]
        static bool Prefix()
        {
            //code here will run BEFORE original code is executed.
            //if 'true' is returned, the original code will still run.
            //if 'false' is returned, the original code will be skipped.
            return true;
        }

        [PatchPrefix]
        static void Postfix(MenuScreen __instance, GameObject ____alphaWarningGameObject)
        {
            ____alphaWarningGameObject.SetActive(false);
            Logger.LogInfo($"Attempted to Disable");
            //code here will run AFTER the original code is executed.
        }

        //don't forget to add 'new FiniteJumpPatch().Enable();' to the Awake() method of your Plugin.cs script to enable this patch.
    }
}
