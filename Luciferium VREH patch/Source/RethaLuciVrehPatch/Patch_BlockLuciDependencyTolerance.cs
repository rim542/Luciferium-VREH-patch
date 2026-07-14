using HarmonyLib;
using RimWorld;
using Verse;

namespace RethaLuciVrehPatch
{
    [HarmonyPatch(typeof(IngestionOutcomeDoer_GiveHediff), "DoIngestionOutcomeSpecial")]
    public static class Patch_BlockLuciDependencyTolerance
    {
        static HediffDef toleranceDef;
        static GeneDef dependencyGene;

        static bool Prefix(IngestionOutcomeDoer_GiveHediff __instance, Pawn pawn)
        {
            toleranceDef ??= DefDatabase<HediffDef>.GetNamedSilentFail("USH_LuciferiumTolerance");
            dependencyGene ??= DefDatabase<GeneDef>.GetNamedSilentFail("VREH_ChemicalDependency_Luciferium");

            if (toleranceDef == null || dependencyGene == null)
                return true; // one of the two mods isn't loaded, don't interfere

            if (__instance.hediffDef == toleranceDef
                && pawn.genes != null
                && pawn.genes.HasActiveGene(dependencyGene))
            {
                return false; // dependency gene fully blocks tolerance gain
            }
            return true;
        }
    }
}