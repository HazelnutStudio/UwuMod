using HarmonyLib;
using Il2CppHabitanks.UI;
using System;

namespace Hazelnut272.UwuMod
{
    [HarmonyPatch(typeof(TipList), nameof(TipList.ShowTip), new Type[] { typeof(float), typeof(string), typeof(string) })]
    [HarmonyPatch(MethodType.Normal)]
    public static class TipPatch
    {
        public const string TIPBOX_TUTORIAL_MESSAGE = "These tip boxes will explain how to play the demo. (You can turn off tips in the pause menu.)";
        public const string TRAIL_TUTORIAL_MESSAGE = "Click and drag your Castle to draw a <#FF8FB4>Pheromone Trail.</color> Your Antlings will follow the trail.";
        public const string GLOOP_TUTORIAL_MESSAGE = "<#FFB933>Gloop</color> is a building material made from the resources you collect each day. Open the Build Menu to spend it.";
        public const string DAYTIME_TUTORIAL_MESSAGE = "Go to daytime by clicking the Play button in the corner.";
        public const string CRAFTER_TUTORIAL_MESSAGE = "Connect <#FFB933>Crafter</color> buildings to a <#FF8FB4>Pheromone Trail</color> to make your Antlings deliver resources to it.";
        public const string SKIP_TIP_MESSAGE = "Tip: You can fast-forward the daytime by holding the clock button.";
        public static void Prefix(ref float delay, ref string key, ref string text)
        {
            Main.Log($"YIPPEE!! {key}, {text}");

            switch (text)
            {
                case TIPBOX_TUTORIAL_MESSAGE:
                    text = "These tip boxes wiww expwain how tuwu pway the demo. (you cawn tuwn off tips in the pause menu ^-^)";
                    break;
                case TRAIL_TUTORIAL_MESSAGE:
                    text = "Cwick awnd dwag youw castwe tuwu dwaw a <#FF8FB4>phewomone twaiw.</color> youw antwings wiww fowwow the twaiw :3";
                    break;
                case GLOOP_TUTORIAL_MESSAGE:
                    text = "<#ffb933>gwoop</color> iws a buiwding matewiaw made fwom the wesouwces uwu cowwect each day. Open the buiwd menu tuwu spend iwt. T_T";
                    break;
                case DAYTIME_TUTORIAL_MESSAGE:
                    text = "Gow tuwu daytime by cwicking the pway button in the cownew QwQ";
                    break;
                case CRAFTER_TUTORIAL_MESSAGE:
                    text = "Connect <#ffb933>cwaftew</color> buiwdings tuwu a <#ff8fb4>phewomone twaiw</color> tuwu make youw antwings dewivew wesouwces tuwu iwt.";
                    break;
                case SKIP_TIP_MESSAGE:
                    text = "Tip: uwu cawn fast-fowwawd the daytime by howding the cwock button \\^o^/";
                    break;
                default:
                    text = "i haven't twanswated thiws owne yet uwu";
                    break;
            }
        }
    }
}