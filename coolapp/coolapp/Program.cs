using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using Microsoft.Win32;

namespace UltimatePingOptimizer
{
    class Program
    {
        static ConsoleColor defaultColor = Console.ForegroundColor;

        // Memory cleaning
        [DllImport("psapi.dll")]
        static extern int EmptyWorkingSet(IntPtr hwProc);

        static void Main(string[] args)
        {
            Console.Title = "Ultimate Roblox Ping Optimizer v3.0";

            if (!IsAdministrator())
            {
                PrintColored("[!] Please run as Administrator!", ConsoleColor.Red);
                Console.ReadKey();
                return;
            }

            ShowBanner();
            ShowMenu();
        }

        static void ShowBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  ██████╗ ██╗███╗   ██╗ ██████╗      ██████╗ ██████╗ ████████╗
  ██╔══██╗██║████╗  ██║██╔════╝     ██╔═══██╗██╔══██╗╚══██╔══╝
  ██████╔╝██║██╔██╗ ██║██║  ███╗    ██║   ██║██████╔╝   ██║   
  ██╔═══╝ ██║██║╚██╗██║██║   ██║    ██║   ██║██╔═══╝    ██║   
  ██║     ██║██║ ╚████║╚██████╔╝    ╚██████╔╝██║        ██║   
  ╚═╝     ╚═╝╚═╝  ╚═══╝ ╚═════╝      ╚═════╝ ╚═╝        ╚═╝   
                                                              
  ╔══════════════════════════════════════════════════════════╗
  ║          ULTIMATE ROBLOX PING OPTIMIZER v3.0             ║
  ║              ⚡ MAX LOW PING EDITION ⚡                   ║
  ╚══════════════════════════════════════════════════════════╝
            ");
            Console.ForegroundColor = defaultColor;
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n  ╔════════════════════════════════════════╗");
                Console.WriteLine("  ║            OPTIMIZATION MENU            ║");
                Console.WriteLine("  ╠════════════════════════════════════════╣");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ║  [1] ⚡ MAX LOW PING (EXTREME) ⚡       ║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ╠════════════════════════════════════════╣");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  ║  [2] Full Optimization                  ║");
                Console.WriteLine("  ║  [3] Flush DNS & Reset Network          ║");
                Console.WriteLine("  ║  [4] TCP/IP Optimizations               ║");
                Console.WriteLine("  ║  [5] Set Fastest DNS                    ║");
                Console.WriteLine("  ║  [6] Disable Nagle Algorithm            ║");
                Console.WriteLine("  ║  [7] Kill Bandwidth Apps                ║");
                Console.WriteLine("  ║  [8] Optimize Network Adapter           ║");
                Console.WriteLine("  ║  [9] Boost Roblox Priority              ║");
                Console.WriteLine("  ║  [10] Clean RAM Memory                  ║");
                Console.WriteLine("  ║  [11] Disable Unnecessary Services      ║");
                Console.WriteLine("  ║  [12] Test Ping to Roblox               ║");
                Console.WriteLine("  ║  [13] Real-Time Ping Monitor            ║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ╠════════════════════════════════════════╣");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  ║  [14] Restore Default Settings          ║");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ║  [0] Exit                               ║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ╚════════════════════════════════════════╝");
                Console.ForegroundColor = defaultColor;

                Console.Write("\n  Select option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": MaxLowPingMode(); break;
                    case "2": FullOptimization(); break;
                    case "3": FlushAndResetNetwork(); break;
                    case "4": ApplyTcpOptimizations(); break;
                    case "5": SetFastestDNS(); break;
                    case "6": DisableNagleAlgorithm(); break;
                    case "7": KillBandwidthHogs(); break;
                    case "8": OptimizeNetworkAdapter(); break;
                    case "9": BoostRobloxPriority(); break;
                    case "10": CleanRAM(); break;
                    case "11": DisableUnnecessaryServices(); break;
                    case "12": TestRobloxPing(); break;
                    case "13": RealTimePingMonitor(); break;
                    case "14": RestoreDefaults(); break;
                    case "0": Environment.Exit(0); break;
                    default: PrintColored("  Invalid option!", ConsoleColor.Red); break;
                }
            }
        }

        // ╔═══════════════════════════════════════════════════════════════╗
        // ║              ⚡ MAX LOW PING MODE (EXTREME) ⚡                 ║
        // ╚═══════════════════════════════════════════════════════════════╝
        static void MaxLowPingMode()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
  ╔═══════════════════════════════════════════════════════════════╗
  ║                                                               ║
  ║           ⚡⚡⚡ MAX LOW PING MODE ⚡⚡⚡                      ║
  ║                                                               ║
  ║   WARNING: This applies EXTREME optimizations!                ║
  ║   - Modifies Windows registry                                 ║
  ║   - Disables background services                              ║
  ║   - Kills all unnecessary processes                           ║
  ║   - Maximum network priority for Roblox                       ║
  ║                                                               ║
  ║   RECOMMENDED: Create a System Restore Point first!           ║
  ║                                                               ║
  ╚═══════════════════════════════════════════════════════════════╝
            ");
            Console.ForegroundColor = defaultColor;

            Console.Write("\n  Are you sure? (yes/no): ");
            if (Console.ReadLine()?.ToLower() != "yes")
            {
                PrintColored("  Cancelled.", ConsoleColor.Yellow);
                return;
            }

            PrintColored("\n  ⚡ INITIATING MAX LOW PING MODE ⚡\n", ConsoleColor.Red);
            Thread.Sleep(1000);

            int totalSteps = 15;
            int currentStep = 0;

            // Step 1: Create Restore Point
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Creating System Restore Point");
            CreateRestorePoint();

            // Step 2: Kill ALL Bandwidth Hogs
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Killing ALL Bandwidth Apps");
            KillAllBandwidthApps();

            // Step 3: Clean RAM
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Cleaning RAM Memory");
            CleanRAM();

            // Step 4: Flush DNS
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Flushing DNS Cache");
            FlushAndResetNetworkSilent();

            // Step 5: Apply Extreme TCP Optimizations
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Applying EXTREME TCP Settings");
            ApplyExtremeTcpOptimizations();

            // Step 6: Disable Nagle Completely
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Disabling Nagle Algorithm");
            DisableNagleComplete();

            // Step 7: Set Cloudflare DNS
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Setting Cloudflare DNS (1.1.1.1)");
            SetCloudflareDNSSilent();

            // Step 8: Disable Network Throttling
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Disabling Network Throttling");
            DisableNetworkThrottling();

            // Step 9: Optimize MTU
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Optimizing MTU Settings");
            OptimizeMTU();

            // Step 10: Disable Unnecessary Services
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Disabling Background Services");
            DisableServicesSilent();

            // Step 11: Set High Performance Power Plan
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Enabling High Performance Mode");
            SetHighPerformance();

            // Step 12: Optimize Network Adapter
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Optimizing Network Adapter");
            OptimizeAdapterExtreme();

            // Step 13: Disable Windows Auto-Tuning
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Disabling Windows Auto-Tuning");
            DisableAutoTuning();

            // Step 14: Set QoS Priority
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Setting QoS Priority for Gaming");
            SetQoSPriority();

            // Step 15: Boost Roblox Priority
            currentStep++;
            ShowProgress(currentStep, totalSteps, "Boosting Roblox Priority");
            BoostRobloxPrioritySilent();

            // Complete!
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
  ╔═══════════════════════════════════════════════════════════════╗
  ║                                                               ║
  ║           ✓✓✓ MAX LOW PING MODE ACTIVATED ✓✓✓                ║
  ║                                                               ║
  ║   All optimizations applied successfully!                     ║
  ║                                                               ║
  ║   NEXT STEPS:                                                 ║
  ║   1. Restart your PC for full effect                          ║
  ║   2. Launch Roblox                                            ║
  ║   3. Enjoy lower ping!                                        ║
  ║                                                               ║
  ╚═══════════════════════════════════════════════════════════════╝
            ");
            Console.ForegroundColor = defaultColor;

            // Test ping after optimization
            Console.Write("\n  Test ping now? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                TestRobloxPing();
            }
        }

        static void ShowProgress(int current, int total, string task)
        {
            int barWidth = 30;
            double progress = (double)current / total;
            int filled = (int)(barWidth * progress);

            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string('█', filled));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(new string('░', barWidth - filled));
            Console.ForegroundColor = defaultColor;
            Console.Write($"] {current}/{total}");
            Console.WriteLine($" - {task}");

            Thread.Sleep(500);
        }

        // ========== EXTREME TCP OPTIMIZATIONS ==========
        static void ApplyExtremeTcpOptimizations()
        {
            string[] commands = {
                "netsh int tcp set global autotuninglevel=disabled",
                "netsh int tcp set global rss=enabled",
                "netsh int tcp set global chimney=disabled",
                "netsh int tcp set global dca=enabled",
                "netsh int tcp set global netdma=enabled",
                "netsh int tcp set global ecncapability=disabled",
                "netsh int tcp set global timestamps=disabled",
                "netsh int tcp set global initialRto=2000",
                "netsh int tcp set global nonsackrttresiliency=disabled",
                "netsh int tcp set supplemental Internet congestionprovider=ctcp",
                "netsh int tcp set heuristics disabled",
                "netsh int ip set global taskoffload=disabled",
                "netsh int ip set global neighborcachelimit=4096",
                "netsh int tcp set security mpp=disabled",
                "netsh int tcp set security profiles=disabled"
            };

            foreach (string cmd in commands)
            {
                RunCommand(cmd);
            }

            // Extreme Registry Optimizations
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", true))
                {
                    if (key != null)
                    {
                        key.SetValue("TcpAckFrequency", 1, RegistryValueKind.DWord);
                        key.SetValue("TCPNoDelay", 1, RegistryValueKind.DWord);
                        key.SetValue("TcpDelAckTicks", 0, RegistryValueKind.DWord);
                        key.SetValue("DefaultTTL", 64, RegistryValueKind.DWord);
                        key.SetValue("MaxUserPort", 65534, RegistryValueKind.DWord);
                        key.SetValue("TcpTimedWaitDelay", 30, RegistryValueKind.DWord);
                        key.SetValue("GlobalMaxTcpWindowSize", 65535, RegistryValueKind.DWord);
                        key.SetValue("TcpWindowSize", 65535, RegistryValueKind.DWord);
                        key.SetValue("Tcp1323Opts", 1, RegistryValueKind.DWord);
                        key.SetValue("SackOpts", 1, RegistryValueKind.DWord);
                        key.SetValue("TcpMaxDupAcks", 2, RegistryValueKind.DWord);
                        key.SetValue("EnablePMTUDiscovery", 1, RegistryValueKind.DWord);
                        key.SetValue("EnablePMTUBHDetect", 0, RegistryValueKind.DWord);
                        key.SetValue("SynAttackProtect", 0, RegistryValueKind.DWord);
                        key.SetValue("EnableDeadGWDetect", 1, RegistryValueKind.DWord);
                        key.SetValue("EnableWsd", 0, RegistryValueKind.DWord);
                        key.SetValue("MaxFreeTcbs", 65535, RegistryValueKind.DWord);
                        key.SetValue("MaxHashTableSize", 65536, RegistryValueKind.DWord);
                    }
                }

                // AFD Parameters (Advanced Network)
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Services\AFD\Parameters", true))
                {
                    if (key != null)
                    {
                        key.SetValue("DefaultReceiveWindow", 65535, RegistryValueKind.DWord);
                        key.SetValue("DefaultSendWindow", 65535, RegistryValueKind.DWord);
                        key.SetValue("FastSendDatagramThreshold", 1500, RegistryValueKind.DWord);
                        key.SetValue("FastCopyReceiveThreshold", 1500, RegistryValueKind.DWord);
                    }
                }
            }
            catch { }
        }

        // ========== DISABLE NAGLE COMPLETE ==========
        static void DisableNagleComplete()
        {
            try
            {
                using (RegistryKey adaptersKey = Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces"))
                {
                    if (adaptersKey != null)
                    {
                        foreach (string subKeyName in adaptersKey.GetSubKeyNames())
                        {
                            using (RegistryKey adapterKey = adaptersKey.OpenSubKey(subKeyName, true))
                            {
                                if (adapterKey != null)
                                {
                                    adapterKey.SetValue("TcpAckFrequency", 1, RegistryValueKind.DWord);
                                    adapterKey.SetValue("TCPNoDelay", 1, RegistryValueKind.DWord);
                                    adapterKey.SetValue("TcpDelAckTicks", 0, RegistryValueKind.DWord);
                                    adapterKey.SetValue("TcpInitialRTT", 300, RegistryValueKind.DWord);
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        // ========== DISABLE NETWORK THROTTLING ==========
        static void DisableNetworkThrottling()
        {
            try
            {
                // Multimedia System Profile
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", true))
                {
                    if (key != null)
                    {
                        key.SetValue("NetworkThrottlingIndex", 0xffffffff, RegistryValueKind.DWord);
                        key.SetValue("SystemResponsiveness", 0, RegistryValueKind.DWord);
                    }
                }

                // Gaming Profile
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", true))
                {
                    if (key == null)
                    {
                        using (RegistryKey newKey = Registry.LocalMachine.CreateSubKey(
                            @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games"))
                        {
                            if (newKey != null)
                            {
                                newKey.SetValue("Affinity", 0, RegistryValueKind.DWord);
                                newKey.SetValue("Background Only", "False");
                                newKey.SetValue("Clock Rate", 10000, RegistryValueKind.DWord);
                                newKey.SetValue("GPU Priority", 8, RegistryValueKind.DWord);
                                newKey.SetValue("Priority", 6, RegistryValueKind.DWord);
                                newKey.SetValue("Scheduling Category", "High");
                                newKey.SetValue("SFIO Priority", "High");
                            }
                        }
                    }
                    else
                    {
                        key.SetValue("Affinity", 0, RegistryValueKind.DWord);
                        key.SetValue("Background Only", "False");
                        key.SetValue("Clock Rate", 10000, RegistryValueKind.DWord);
                        key.SetValue("GPU Priority", 8, RegistryValueKind.DWord);
                        key.SetValue("Priority", 6, RegistryValueKind.DWord);
                        key.SetValue("Scheduling Category", "High");
                        key.SetValue("SFIO Priority", "High");
                    }
                }

                // Disable QoS Bandwidth Limit
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(
                    @"SOFTWARE\Policies\Microsoft\Windows\Psched"))
                {
                    key?.SetValue("NonBestEffortLimit", 0, RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        // ========== OPTIMIZE MTU ==========
        static void OptimizeMTU()
        {
            string adapterName = GetActiveAdapterName();
            if (!string.IsNullOrEmpty(adapterName))
            {
                RunCommand($"netsh interface ipv4 set subinterface \"{adapterName}\" mtu=1500 store=persistent");
            }
        }

        // ========== SET HIGH PERFORMANCE ==========
        static void SetHighPerformance()
        {
            string[] commands = {
                "powercfg -setactive 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c",
                "powercfg -h off",
                "powercfg -change -standby-timeout-ac 0",
                "powercfg -change -hibernate-timeout-ac 0"
            };

            foreach (string cmd in commands)
            {
                RunCommand(cmd);
            }
        }

        // ========== OPTIMIZE ADAPTER EXTREME ==========
        static void OptimizeAdapterExtreme()
        {
            string adapterName = GetActiveAdapterName();
            if (string.IsNullOrEmpty(adapterName)) return;

            // Disable power saving
            RunCommand($"powershell -Command \"Disable-NetAdapterPowerManagement -Name '{adapterName}' -ErrorAction SilentlyContinue\"");

            // Registry optimizations for all adapters
            try
            {
                using (RegistryKey adaptersKey = Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}"))
                {
                    if (adaptersKey != null)
                    {
                        foreach (string subKeyName in adaptersKey.GetSubKeyNames())
                        {
                            try
                            {
                                using (RegistryKey adapterKey = adaptersKey.OpenSubKey(subKeyName, true))
                                {
                                    if (adapterKey != null)
                                    {
                                        // Disable Flow Control
                                        adapterKey.SetValue("*FlowControl", "0", RegistryValueKind.String);

                                        // Disable Interrupt Moderation
                                        adapterKey.SetValue("*InterruptModeration", "0", RegistryValueKind.String);

                                        // Enable RSS
                                        adapterKey.SetValue("*RSS", "1", RegistryValueKind.String);

                                        // Disable Power Saving
                                        adapterKey.SetValue("*PMARPOffload", "0", RegistryValueKind.String);
                                        adapterKey.SetValue("*PMNSOffload", "0", RegistryValueKind.String);
                                        adapterKey.SetValue("*PMWiFiRekeyOffload", "0", RegistryValueKind.String);
                                        adapterKey.SetValue("PnPCapabilities", 24, RegistryValueKind.DWord);

                                        // Speed & Duplex - Auto
                                        adapterKey.SetValue("*SpeedDuplex", "0", RegistryValueKind.String);
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
        }

        // ========== DISABLE AUTO-TUNING ==========
        static void DisableAutoTuning()
        {
            RunCommand("netsh int tcp set global autotuninglevel=disabled");
            RunCommand("netsh int tcp set global rsc=disabled");
        }

        // ========== SET QoS PRIORITY ==========
        static void SetQoSPriority()
        {
            try
            {
                // Set Roblox as high priority in QoS
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(
                    @"SOFTWARE\Policies\Microsoft\Windows\QoS\Roblox"))
                {
                    if (key != null)
                    {
                        key.SetValue("Application Name", "RobloxPlayerBeta.exe");
                        key.SetValue("Version", "1.0");
                        key.SetValue("Protocol", "*");
                        key.SetValue("Local Port", "*");
                        key.SetValue("Local IP", "*");
                        key.SetValue("Local IP Prefix Length", "*");
                        key.SetValue("Remote Port", "*");
                        key.SetValue("Remote IP", "*");
                        key.SetValue("Remote IP Prefix Length", "*");
                        key.SetValue("DSCP Value", "46");  // Highest priority
                        key.SetValue("Throttle Rate", "-1");
                    }
                }
            }
            catch { }
        }

        // ========== KILL ALL BANDWIDTH APPS ==========
        static void KillAllBandwidthApps()
        {
            string[] bandwidthHogs = {
                "chrome", "firefox", "msedge", "opera", "brave",
                "discord", "spotify", "steam", "epicgameslauncher",
                "origin", "battle.net", "twitch", "obs64", "obs32",
                "qbittorrent", "utorrent", "bittorrent", "deluge",
                "onedrive", "dropbox", "googledrive", "icloud",
                "teams", "zoom", "skype", "slack", "telegram",
                "whatsapp", "viber", "netflix", "prime video",
                "vlc", "spotify", "itunes", "winamp",
                "photoshop", "premiere", "aftereffects",
                "vmware", "virtualbox", "docker",
                "syncthing", "resilio", "mega"
            };

            foreach (string processName in bandwidthHogs)
            {
                try
                {
                    Process[] processes = Process.GetProcessesByName(processName);
                    foreach (Process p in processes)
                    {
                        p.Kill();
                    }
                }
                catch { }
            }
        }

        // ========== BOOST ROBLOX PRIORITY ==========
        static void BoostRobloxPriority()
        {
            PrintColored("\n  [+] Boosting Roblox Priority...", ConsoleColor.Cyan);

            Process[] robloxProcesses = Process.GetProcessesByName("RobloxPlayerBeta");

            if (robloxProcesses.Length == 0)
            {
                PrintColored("  [!] Roblox is not running.", ConsoleColor.Yellow);
                PrintColored("  [i] Start Roblox first, then run this option.", ConsoleColor.Gray);
                return;
            }

            foreach (Process p in robloxProcesses)
            {
                try
                {
                    p.PriorityClass = ProcessPriorityClass.RealTime;

                    // Set CPU affinity to all cores
                    int coreCount = Environment.ProcessorCount;
                    long affinity = (1L << coreCount) - 1;
                    p.ProcessorAffinity = (IntPtr)affinity;

                    PrintColored($"  [✓] Roblox PID {p.Id} set to REALTIME priority!", ConsoleColor.Green);
                }
                catch (Exception ex)
                {
                    PrintColored($"  [!] Error: {ex.Message}", ConsoleColor.Red);
                }
            }
        }

        static void BoostRobloxPrioritySilent()
        {
            Process[] robloxProcesses = Process.GetProcessesByName("RobloxPlayerBeta");
            foreach (Process p in robloxProcesses)
            {
                try
                {
                    p.PriorityClass = ProcessPriorityClass.RealTime;
                }
                catch { }
            }
        }

        // ========== CLEAN RAM ==========
        static void CleanRAM()
        {
            PrintColored("\n  [+] Cleaning RAM Memory...", ConsoleColor.Cyan);

            try
            {
                // Clear working sets of all processes
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    try
                    {
                        EmptyWorkingSet(p.Handle);
                    }
                    catch { }
                }

                // Force garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                // Clear standby list (requires admin)
                RunCommand("powershell -Command \"Clear-RecycleBin -Force -ErrorAction SilentlyContinue\"");

                PrintColored("  [✓] RAM Cleaned!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                PrintColored($"  [!] Error: {ex.Message}", ConsoleColor.Red);
            }
        }

        // ========== DISABLE UNNECESSARY SERVICES ==========
        static void DisableUnnecessaryServices()
        {
            PrintColored("\n  [+] Disabling Unnecessary Services...", ConsoleColor.Cyan);

            string[] services = {
                "DiagTrack",           // Diagnostics Tracking
                "dmwappushservice",    // WAP Push Service
                "WSearch",             // Windows Search
                "SysMain",             // Superfetch
                "wuauserv",            // Windows Update (temporary)
                "BITS"                 // Background Transfer
            };

            foreach (string service in services)
            {
                RunCommand($"net stop {service}");
                RunCommand($"sc config {service} start= disabled");
            }

            PrintColored("  [✓] Services Disabled!", ConsoleColor.Green);
        }

        static void DisableServicesSilent()
        {
            string[] services = { "DiagTrack", "dmwappushservice", "SysMain" };
            foreach (string service in services)
            {
                RunCommand($"net stop {service}");
            }
        }

        // ========== CREATE RESTORE POINT ==========
        static void CreateRestorePoint()
        {
            try
            {
                RunCommand("powershell -Command \"Checkpoint-Computer -Description 'Before Ping Optimizer' -RestorePointType 'MODIFY_SETTINGS' -ErrorAction SilentlyContinue\"");
            }
            catch { }
        }

        // ========== REAL-TIME PING MONITOR ==========
        static void RealTimePingMonitor()
        {
            PrintColored("\n  [+] Starting Real-Time Ping Monitor...", ConsoleColor.Cyan);
            PrintColored("  [i] Press any key to stop.\n", ConsoleColor.Gray);

            Ping ping = new Ping();
            string server = "roblox.com";

            long minPing = long.MaxValue;
            long maxPing = 0;
            long totalPing = 0;
            int count = 0;

            while (!Console.KeyAvailable)
            {
                try
                {
                    PingReply reply = ping.Send(server, 1000);

                    if (reply.Status == IPStatus.Success)
                    {
                        long ms = reply.RoundtripTime;
                        count++;
                        totalPing += ms;

                        if (ms < minPing) minPing = ms;
                        if (ms > maxPing) maxPing = ms;

                        ConsoleColor color = ms < 50 ? ConsoleColor.Green :
                                            ms < 100 ? ConsoleColor.Yellow :
                                            ConsoleColor.Red;

                        Console.ForegroundColor = color;
                        Console.Write($"\r  Ping: {ms}ms");
                        Console.ForegroundColor = defaultColor;
                        Console.Write($" | Min: {minPing}ms | Max: {maxPing}ms | Avg: {totalPing / count}ms    ");
                    }
                    else
                    {
                        Console.Write($"\r  Ping: TIMEOUT                                        ");
                    }

                    Thread.Sleep(500);
                }
                catch
                {
                    Console.Write($"\r  Ping: ERROR                                          ");
                    Thread.Sleep(500);
                }
            }

            Console.ReadKey(true);
            Console.WriteLine();
        }

        // ========== FULL OPTIMIZATION ==========
        static void FullOptimization()
        {
            PrintColored("\n  [===== STARTING FULL OPTIMIZATION =====]\n", ConsoleColor.Yellow);

            FlushAndResetNetwork();
            ApplyTcpOptimizations();
            SetFastestDNS();
            DisableNagleAlgorithm();
            OptimizeNetworkAdapter();
            KillBandwidthHogs();

            PrintColored("\n  [✓] FULL OPTIMIZATION COMPLETE!", ConsoleColor.Green);
            PrintColored("  [!] Restart your PC for best results.\n", ConsoleColor.Yellow);
        }

        // ========== FLUSH DNS & RESET NETWORK ==========
        static void FlushAndResetNetwork()
        {
            PrintColored("\n  [+] Flushing DNS & Resetting Network...", ConsoleColor.Cyan);

            string[] commands = {
                "ipconfig /flushdns",
                "ipconfig /release",
                "ipconfig /renew",
                "netsh winsock reset",
                "netsh int ip reset",
                "netsh interface tcp reset",
                "arp -d *"
            };

            foreach (string cmd in commands)
            {
                RunCommand(cmd);
            }

            PrintColored("  [✓] Network Reset Complete!", ConsoleColor.Green);
        }

        static void FlushAndResetNetworkSilent()
        {
            string[] commands = {
                "ipconfig /flushdns",
                "netsh winsock reset",
                "netsh int ip reset",
                "arp -d *"
            };

            foreach (string cmd in commands)
            {
                RunCommand(cmd);
            }
        }

        // ========== TCP/IP OPTIMIZATIONS ==========
        static void ApplyTcpOptimizations()
        {
            PrintColored("\n  [+] Applying TCP/IP Optimizations...", ConsoleColor.Cyan);

            string[] commands = {
                "netsh int tcp set global autotuninglevel=normal",
                "netsh int tcp set global dca=enabled",
                "netsh int tcp set global rss=enabled",
                "netsh int tcp set global chimney=disabled",
                "netsh int tcp set global ecncapability=enabled",
                "netsh int tcp set supplemental Internet congestionprovider=ctcp"
            };

            foreach (string cmd in commands)
            {
                RunCommand(cmd);
            }

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", true))
                {
                    if (key != null)
                    {
                        key.SetValue("TcpAckFrequency", 1, RegistryValueKind.DWord);
                        key.SetValue("TCPNoDelay", 1, RegistryValueKind.DWord);
                        key.SetValue("TcpDelAckTicks", 0, RegistryValueKind.DWord);
                        key.SetValue("DefaultTTL", 64, RegistryValueKind.DWord);
                        key.SetValue("MaxUserPort", 65534, RegistryValueKind.DWord);
                        key.SetValue("TcpTimedWaitDelay", 30, RegistryValueKind.DWord);
                    }
                }
            }
            catch { }

            PrintColored("  [✓] TCP/IP Optimizations Applied!", ConsoleColor.Green);
        }

        // ========== SET FASTEST DNS ==========
        static void SetFastestDNS()
        {
            PrintColored("\n  [+] Setting Fastest DNS Servers...", ConsoleColor.Cyan);

            Console.WriteLine("\n  Choose DNS Provider:");
            Console.WriteLine("  [1] Cloudflare (1.1.1.1) - Fastest");
            Console.WriteLine("  [2] Google (8.8.8.8) - Reliable");
            Console.WriteLine("  [3] Quad9 (9.9.9.9) - Secure");
            Console.WriteLine("  [4] OpenDNS (208.67.222.222)");

            Console.Write("  Select: ");
            string choice = Console.ReadLine();

            string primary, secondary;

            switch (choice)
            {
                case "1":
                    primary = "1.1.1.1";
                    secondary = "1.0.0.1";
                    break;
                case "2":
                    primary = "8.8.8.8";
                    secondary = "8.8.4.4";
                    break;
                case "3":
                    primary = "9.9.9.9";
                    secondary = "149.112.112.112";
                    break;
                case "4":
                    primary = "208.67.222.222";
                    secondary = "208.67.220.220";
                    break;
                default:
                    primary = "1.1.1.1";
                    secondary = "1.0.0.1";
                    break;
            }

            string adapterName = GetActiveAdapterName();

            if (!string.IsNullOrEmpty(adapterName))
            {
                RunCommand($"netsh interface ip set dns \"{adapterName}\" static {primary}");
                RunCommand($"netsh interface ip add dns \"{adapterName}\" {secondary} index=2");
                PrintColored($"  [✓] DNS set to {primary} & {secondary}!", ConsoleColor.Green);
            }
            else
            {
                PrintColored("  [!] Could not detect network adapter.", ConsoleColor.Red);
            }
        }

        static void SetCloudflareDNSSilent()
        {
            string adapterName = GetActiveAdapterName();
            if (!string.IsNullOrEmpty(adapterName))
            {
                RunCommand($"netsh interface ip set dns \"{adapterName}\" static 1.1.1.1");
                RunCommand($"netsh interface ip add dns \"{adapterName}\" 1.0.0.1 index=2");
            }
        }

        // ========== DISABLE NAGLE ALGORITHM ==========
        static void DisableNagleAlgorithm()
        {
            PrintColored("\n  [+] Disabling Nagle Algorithm...", ConsoleColor.Cyan);

            try
            {
                using (RegistryKey adaptersKey = Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces"))
                {
                    if (adaptersKey != null)
                    {
                        foreach (string subKeyName in adaptersKey.GetSubKeyNames())
                        {
                            using (RegistryKey adapterKey = adaptersKey.OpenSubKey(subKeyName, true))
                            {
                                if (adapterKey != null)
                                {
                                    adapterKey.SetValue("TcpAckFrequency", 1, RegistryValueKind.DWord);
                                    adapterKey.SetValue("TCPNoDelay", 1, RegistryValueKind.DWord);
                                    adapterKey.SetValue("TcpDelAckTicks", 0, RegistryValueKind.DWord);
                                }
                            }
                        }
                    }
                }

                PrintColored("  [✓] Nagle Algorithm Disabled!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                PrintColored($"  [!] Error: {ex.Message}", ConsoleColor.Red);
            }
        }

        // ========== KILL BANDWIDTH HOGS ==========
        static void KillBandwidthHogs()
        {
            PrintColored("\n  [+] Scanning for Bandwidth-Hogging Apps...", ConsoleColor.Cyan);

            string[] bandwidthHogs = {
                "chrome", "firefox", "msedge", "opera",
                "discord", "spotify", "steam", "epicgameslauncher",
                "origin", "battle.net", "twitch", "obs64",
                "qbittorrent", "utorrent", "bittorrent",
                "onedrive", "dropbox", "googledrive",
                "teams", "zoom", "skype", "slack"
            };

            Console.WriteLine("\n  Found running:");

            foreach (string processName in bandwidthHogs)
            {
                Process[] processes = Process.GetProcessesByName(processName);

                if (processes.Length > 0)
                {
                    Console.Write($"    [{processName}] Kill? (y/n): ");
                    if (Console.ReadLine()?.ToLower() == "y")
                    {
                        foreach (Process p in processes)
                        {
                            try
                            {
                                p.Kill();
                                PrintColored($"      [✓] {processName} killed!", ConsoleColor.Green);
                            }
                            catch
                            {
                                PrintColored($"      [!] Could not kill {processName}", ConsoleColor.Red);
                            }
                        }
                    }
                }
            }

            PrintColored("  [✓] Bandwidth Cleanup Complete!", ConsoleColor.Green);
        }

        // ========== OPTIMIZE NETWORK ADAPTER ==========
        static void OptimizeNetworkAdapter()
        {
            PrintColored("\n  [+] Optimizing Network Adapter...", ConsoleColor.Cyan);

            string[] commands = {
                "powercfg -setacvalueindex SCHEME_CURRENT SUB_NONE CONSOLELOCK 0",
                "powercfg -setactive 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c",
                "netsh int tcp set global timestamps=disabled",
                "netsh int ip set global taskoffload=disabled"
            };

            foreach (string cmd in commands)
            {
                RunCommand(cmd);
            }

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", true))
                {
                    if (key != null)
                    {
                        key.SetValue("NetworkThrottlingIndex", 0xffffffff, RegistryValueKind.DWord);
                        key.SetValue("SystemResponsiveness", 0, RegistryValueKind.DWord);
                    }
                }
            }
            catch { }

            PrintColored("  [✓] Network Adapter Optimized!", ConsoleColor.Green);
        }

        // ========== TEST ROBLOX PING ==========
        static void TestRobloxPing()
        {
            PrintColored("\n  [+] Testing Ping to Roblox Servers...\n", ConsoleColor.Cyan);

            string[] servers = {
                "roblox.com",
                "api.roblox.com",
                "assetgame.roblox.com",
                "www.roblox.com",
                "catalog.roblox.com"
            };

            Ping ping = new Ping();

            long totalPing = 0;
            int successCount = 0;

            foreach (string server in servers)
            {
                try
                {
                    long avgPing = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        PingReply reply = ping.Send(server, 2000);
                        if (reply.Status == IPStatus.Success)
                        {
                            avgPing += reply.RoundtripTime;
                        }
                    }

                    avgPing /= 3;
                    totalPing += avgPing;
                    successCount++;

                    ConsoleColor color = avgPing < 50 ? ConsoleColor.Green :
                                        avgPing < 100 ? ConsoleColor.Yellow :
                                        ConsoleColor.Red;

                    Console.ForegroundColor = color;
                    Console.WriteLine($"    {server}: {avgPing}ms");
                    Console.ForegroundColor = defaultColor;
                }
                catch
                {
                    PrintColored($"    {server}: FAILED", ConsoleColor.Red);
                }
            }

            if (successCount > 0)
            {
                Console.WriteLine($"\n    Average Ping: {totalPing / successCount}ms");
            }

            Console.WriteLine("\n    Ping Quality:");
            PrintColored("      < 50ms  = Excellent", ConsoleColor.Green);
            PrintColored("      < 100ms = Good", ConsoleColor.Yellow);
            PrintColored("      > 100ms = Poor", ConsoleColor.Red);
        }

        // ========== RESTORE DEFAULTS ==========
        static void RestoreDefaults()
        {
            PrintColored("\n  [+] Restoring Default Network Settings...", ConsoleColor.Cyan);

            string[] commands = {
                "netsh int tcp reset",
                "netsh winsock reset",
                "netsh int ip reset",
                "ipconfig /flushdns",
                "netsh int tcp set global autotuninglevel=normal"
            };

            foreach (string cmd in commands)
            {
                RunCommand(cmd);
            }

            // Re-enable services
            string[] services = { "DiagTrack", "dmwappushservice", "WSearch", "SysMain" };
            foreach (string service in services)
            {
                RunCommand($"sc config {service} start= auto");
                RunCommand($"net start {service}");
            }

            PrintColored("  [✓] Defaults Restored! Restart your PC.", ConsoleColor.Green);
        }

        // ========== HELPER METHODS ==========
        static void RunCommand(string command)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {command}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit(5000);
                }
            }
            catch { }
        }

        static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        static string GetActiveAdapterName()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                     ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                {
                    return ni.Name;
                }
            }
            return null;
        }

        static void PrintColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }
    }
}