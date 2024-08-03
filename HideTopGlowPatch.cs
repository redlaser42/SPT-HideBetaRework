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

namespace HideBetaRework.Patches
{
    internal class HideTopGlowPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(EnvironmentUI), nameof(EnvironmentUI.method_0));
        }

        [PatchPostfix]
        static void Postfix(EnvironmentUI __instance, Image ____imageToFadeIn)
        {
            ____imageToFadeIn.color = new Color(0f, 0f, 0f, 1f);
        }
    }
}
