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
            return AccessTools.Method(typeof(PreloaderUI), nameof(PreloaderUI.method_6));
        }

        [PatchPostfix]
        static void Postfix(PreloaderUI __instance, LocalizedText ____alphaVersionLabel)
        {
            ____alphaVersionLabel.gameObject.SetActive(false);
        }
    }
}
