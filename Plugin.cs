using System;
using System.ComponentModel;
using Christmas.Scp2536;
using Christmas.Scp2536.Gifts;
using HarmonyLib;
using InventorySystem;
using PluginAPI;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace Anti2536
{
    [HarmonyPatch(typeof(Scp2536Controller), "CanFindPosition")]
    static class PreventScp2536
    {
        public static bool Prefix(ref bool __result)
        {
            // Log.Debug($"Preventing Christmas Tree Spawn");
            __result = false;
            return false;
        }
    }
    
    
    public class Plugin
    {
        public static Harmony Harmony { get; private set; }
        
        [PluginConfig("configs/anti2536.yml")] 
        public Config Config;
        

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("Anti2536", "1.0.0", "Prevents SCP-2536/Christmas Tree from spawning.", "kusudo")]
        void LoadPlugin()
        {
            //Log.Info(this.Config.isEnabled.ToString());
            if (this.Config.disableScp2536)
            {
                Harmony = new Harmony("Anti2536"); 
                Harmony.PatchAll(); 
                Log.Info("Patching completed. Plugin loading finished.");
                Log.Info("SCP-2536 is DISABLED");
            }
            else
            {
                Log.Info("SCP-2536 is ENABLED (to change this modify the plugin's config)");
            }
        }

        [PluginUnload]
        void UnloadPlugin()
        {
            Harmony.UnpatchAll();
        }

       

    }
}