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

namespace HideBetaRework.Patches
{
    internal class HideGameModePatch : ModulePatch
    {

        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(MenuScreen), nameof(MenuScreen.method_3));
        }

        [PatchPostfix]
        static void Postfix(MenuScreen __instance, ChangeGameModeButton ____toggleGameModeButton)
        {
            ____toggleGameModeButton.gameObject.SetActive(false);
        }
    }
}
