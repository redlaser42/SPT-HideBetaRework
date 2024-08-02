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
using UnityEngine.UI;

//this example patch will limit the number of jumps you can do to 3, and log whether or not your jump was successful

namespace HideBetaRework.Patches
{
    internal class HideVersionPatch : ModulePatch //we must inherit ModulePatch for our patch to work.
    {

        protected override MethodBase GetTargetMethod()
        {
            //methods are patched by targeting both their class name and the name of the method itself.
            //the example in this patch is the Jump() method in the Player class
            return AccessTools.Method(typeof(PreloaderUI), nameof(PreloaderUI.Awake));
        }


        [PatchPostfix]
        static void Postfix(PreloaderUI __instance, GameObject AlphaLable)
        {
            AlphaLable.SetActive(false);
        }

        //don't forget to add 'new FiniteJumpPatch().Enable();' to the Awake() method of your Plugin.cs script to enable this patch.
    }
}
