using HarmonyLib;
using Verse;

namespace RethaLuciVrehPatch
{
    public class RethaPatchMod : Mod
    {
        public RethaPatchMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("retha.patch");
            harmony.PatchAll();
        }
    }
}