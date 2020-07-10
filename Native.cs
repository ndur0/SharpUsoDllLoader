using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace UsoSvc
{ 
    public class Native
    {

        [DllImport("ole32.dll", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        internal static extern void CoCreateInstance(
            [MarshalAs(UnmanagedType.LPStruct)] [In] Guid rclsid,
            [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
            uint dwClsCtx,
            [MarshalAs(UnmanagedType.LPStruct)] [In] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] out object returnedComObject    //out object returnedComObject    //out IUpdateSessionOrchestrator pInterface     //ref IntPtr pInterface // out IUpdateSessionOrchestrator orchestrator    //out object returnedComObject
        );


        [DllImport("ole32.dll", SetLastError = true, ExactSpelling = true, PreserveSig = false)]  //CharSet = CharSet.Unicode,
        internal static extern int CoSetProxyBlanket([MarshalAs(UnmanagedType.IUnknown)]
            object pProxy,
            uint dwAuthnSvc,
            uint dwAuthzSvc,
            uint pServerPrincName,
            uint dwAuthnLevel,
            uint dwImpLevel,
            IntPtr pAuthInfo,
            uint dwCapabilities
        );

               
        public const uint RPC_C_AUTHN_DEFAULT = 0xffffffff;
        public const uint RPC_C_AUTHZ_DEFAULT = 0xffffffff;
        public const uint RPC_C_AUTHN_LEVEL_PKT_PRIVACY = 6;
        public const uint RPC_C_IMP_LEVEL_DEFAULT = 3;
        public const uint COLE_DEFAULT_AUTHINFO = 0xffffffff;
        public const uint COLE_DEFAULT_PRINCIPAL = 0; //0
        public const uint EOAC_DEFAULT = 0;
        public const uint RPC_C_AUTHN_LEVEL_DEFAULT = 0;

        

        public enum UsoAction
        {
            USO_STARTSCAN,
            USO_STARTDOWNLOAD,
            USO_STARTINSTALL,
            USO_REFRESHSETTINGS,
            USO_STARTINTERACTIVESCAN,
            USO_RESTARTDEVICE,
            USO_SCANINSTALLWAIT,
            USO_RESUMEUPDATE
        };


        [Flags]
        public enum COINIT : uint //tagCOINIT
        {
            COINIT_MULTITHREADED = 0x0, //Initializes the thread for multi-threaded object concurrency.
            COINIT_APARTMENTTHREADED = 0x2, //Initializes the thread for apartment-threaded object concurrency
            COINIT_DISABLE_OLE1DDE = 0x4, //Disables DDE for OLE1 support
            COINIT_SPEED_OVER_MEMORY = 0x8, //Trade memory for speed
        }

        [Flags]
        public enum CLSCTX : uint
        {
            CLSCTX_INPROC_SERVER = 0x1,
            CLSCTX_INPROC_HANDLER = 0x2,
            CLSCTX_LOCAL_SERVER = 0x4,
            CLSCTX_INPROC_SERVER16 = 0x8,
            CLSCTX_REMOTE_SERVER = 0x10,
            CLSCTX_INPROC_HANDLER16 = 0x20,
            CLSCTX_RESERVED1 = 0x40,
            CLSCTX_RESERVED2 = 0x80,
            CLSCTX_RESERVED3 = 0x100,
            CLSCTX_RESERVED4 = 0x200,
            CLSCTX_NO_CODE_DOWNLOAD = 0x400,
            CLSCTX_RESERVED5 = 0x800,
            CLSCTX_NO_CUSTOM_MARSHAL = 0x1000,
            CLSCTX_ENABLE_CODE_DOWNLOAD = 0x2000,
            CLSCTX_NO_FAILURE_LOG = 0x4000,
            CLSCTX_DISABLE_AAA = 0x8000,
            CLSCTX_ENABLE_AAA = 0x10000,
            CLSCTX_FROM_DEFAULT_CONTEXT = 0x20000,
            CLSCTX_ACTIVATE_32_BIT_SERVER = 0x40000,
            CLSCTX_ACTIVATE_64_BIT_SERVER = 0x80000,
            CLSCTX_INPROC = CLSCTX_INPROC_SERVER | CLSCTX_INPROC_HANDLER,
            CLSCTX_SERVER = CLSCTX_INPROC_SERVER | CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER,
            CLSCTX_ALL = CLSCTX_SERVER | CLSCTX_INPROC_HANDLER
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct_5
        {
            int Member0;
            int Member4;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct_23
        {
            Guid Member0;
            int Member10;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct_24
        {
            int Member0;
            int Member4;
            int Member8;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct_25
        {
            int Member0;
            int Member4;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct_26
        {
            int Member0;
            int Member4;
            Struct_5 Member8;
            Struct_25 Member10;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct_33
        {
            int Member0;
            int Member4;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct_49
        {
            short Member0;
            short Member2;
            short Member4;
            short Member6;
            short Member8;
            short MemberA;
            short MemberC;
            short MemberE;
        };

        [ComImport]
        [Guid("07f3afac-7c8a-4ce7-a5e0-3d24ee8a77e0")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUpdateSessionOrchestrator
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            
            IUpdateSessionOrchestrator CreateUpdateSession(int param_1, Guid param_2, [MarshalAs(UnmanagedType.Interface)] out IUsoSessionCommon common);    //out object common    //out object returnedComObject //out object pInterface);  //ref IntPtr pInterface) //out UsoSessionCommon pointer //out IntPtr pointer
            [MethodImpl(MethodImplOptions.InternalCall)]
            void GetCurrentActiveUpdateSessions(IUsoSessionCollection param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void LogTaskRunning([MarshalAs(UnmanagedType.LPWStr)] [In] string param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void CreateUxUpdateManager(IUxUpdateManager param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void CreateUniversalOrchestrator(IUniversalOrchestrator param_1);
        }


        [ComImport]
        [Guid("c53f3549-0dbf-429a-8297-c812ba00742d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUniversalOrchestrator
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(string param_1, int param_2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc4(string param_1, string param_2, string param_3, string param_4);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc5(string param_1, int param_2);
        }


        [ComImport]
        [Guid("833ee9a0-2999-432c-8ef2-87a8ec2d748d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUxUpdateManager
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(int p0, int p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc4(int p0, int p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc5(int p0, Struct_49 p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc6(int p0, int p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc7(int p0, int p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc8(int p0, Struct_49 p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc9(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc10(int p0, Struct_49 p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc11(string p0, Struct_49 p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc12();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc13();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc14();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc15(Struct_49 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc16();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc17(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc18();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc19();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc20();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc21();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc22();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc23();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc24(int p0, int p1, int p2, short p3, short p4, int p5);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc25(int p0, int p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc26(int p0, int p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc27(int p0, object p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc28(int p0, object p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc29(int p0, short p1, object p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc30(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc31(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc32(int p0, int p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc33(int p0);

        }



        [ComImport]
        [Guid("a244654f-a777-4739-a8e2-5fd4abbd6799")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUsoSessionCollection
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc4(int p0, IUsoSession p1);
        }



        [ComImport]
        [Guid("fccc288d-b47e-41fa-970c-935ec952f4a4")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUsoSessionCommon : IUsoSession
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc32(IUsoUpdateCollection p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc33(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc34(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc35(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc36(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc37(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc38(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc39(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc40(int p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc41(int p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc42(string p0, string p1, string p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc43(string p0, string p1, string p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc44(int p0, object p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc45(int p0, long p1, long p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc46();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc47(int p0, short p1, object p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc48(int p0, int p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc49(int p0, object p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc50(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc51(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc52();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc53(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc54(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc55();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc56(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc57(int p0, object p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc58(int p0, object p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc59(int p0, IUsoSettingObject p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc60(int p0, IUsoSettingArray p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc61();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc62();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc63();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc64(int p0, int p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc65(int p0, int p1, Struct_33 p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc66(IUsoUpdateCollection p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc67();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc68();
        }


        [ComImport]
        [Guid("edb89974-450a-4370-be41-70132df7119e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUsoSettingObject
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc4(string p0, IUsoSettingObject p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc5(string p0, IUsoSettingArray p1);
        }


        [ComImport]
        [Guid("da4baa07-66c8-499a-828d-ba8ff181717c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUsoSettingArray
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(int p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc4(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc5(int p0, IUsoSettingObject p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc6(int p0, IUsoSettingArray p1);
        }



        [ComImport]
        [Guid("b357f841-2130-454e-802c-5c398b549f8e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUsoSession
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(Guid p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc4(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc5(Struct_24 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc6(Struct_25 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc7(int p0, IUsoUpdateCollection p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc8(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc9(Struct_5 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc10(Struct_5 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc11(Struct_5 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc12(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc13(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc14(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc15([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc16([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc17(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc18();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc19();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc20(int p0, int p1, int p2, short p3, short p4, int p5);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc21(uint p0, short p1, [MarshalAs(UnmanagedType.LPWStr)] [In] string p2); // Proc21(short p0, short p1, wchar_t* p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc22(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc23(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc24();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc25(int p0, int p1, IUsoUpdateHistoryEntryCollection p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc26(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc27(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc28(string p0, int p1, string p2); // HRESULT Proc28(/* Stack Offset: 8 */ [In] /* C:(FC_TOP_LEVEL_CONFORMANCE)(16)(FC_ZERO)(FC_ULONG)(0) */ /* unique */wchar_t*[]* p0, /* Stack Offset: 16 */ [In] int p1, /* Stack Offset: 24 */ [In] wchar_t* p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc29(int p0, string p1, int p2); // HRESULT Proc29(/* Stack Offset: 8 */ [In] int p0, /* Stack Offset: 16 */ [Out] /* (FC_TOP_LEVEL_CONFORMANCE)(24)(FC_ZERO)(FC_ULONG)(0) */wchar_t[1]* p1, /* Stack Offset: 24 */ [In] int p2);
            [MethodImpl(MethodImplOptions.InternalCall)] void Proc30();
            void Proc31(int p0);
        }


        [ComImport]
        [Guid("7b51947d-62f0-4e71-af2d-c337dff99e57")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUsoUpdateHistoryEntryCollection
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc4(int p0, IUsoUpdateHistoryEntry p1);
        }


        [ComImport]
        [Guid("580cf13a-20a4-4adc-9322-6dcb8f5c0d0c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUsoUpdateHistoryEntry
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(Struct_23 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc4(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc5(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc6(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc7(double p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc8([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc9([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc10([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc11(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc12([MarshalAs(UnmanagedType.BStr)] string p0, int p1); // HRESULT Proc12(/* Stack Offset: 8 */ [Out] /* C:(FC_TOP_LEVEL_CONFORMANCE)(16)(FC_DEREFERENCE)(FC_LONG)(0) */ [MarshalAs(UnmanagedType.BStr)] string[]* p0, /* Stack Offset: 16 */ [Out] int p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc13(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc14([MarshalAs(UnmanagedType.BStr)] string p0);
        }


        [ComImport]
        [Guid("a1e78367-46b7-4ac8-affa-d9f55645223b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUsoUpdateCollection
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(int p0, IUsoUpdate p1);
            //void Proc4(IUnknown p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc5(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc6();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc7(int p0);
        }


        [ComImport]
        [Guid("d960b85b-11b6-4442-a45c-771283ed293a")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUsoUpdate
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc3(Struct_26 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc4(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc5(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc6([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc7([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc8(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc9(Struct_23 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc10([MarshalAs(UnmanagedType.BStr)] string p0, int p1); // HRESULT Proc10(/* Stack Offset: 8 */ [Out] /* C:(FC_TOP_LEVEL_CONFORMANCE)(16)(FC_DEREFERENCE)(FC_LONG)(0) */ [MarshalAs(UnmanagedType.BStr)] string[]* p0, /* Stack Offset: 16 */ [Out] int p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc11([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc12(double p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc13(object p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc14([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc15(long p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc16(long p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc17(long p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc18();
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc19([MarshalAs(UnmanagedType.BStr)] string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc20([MarshalAs(UnmanagedType.BStr)] string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc21(int p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            void Proc22();
        }

        [ComImport]
        [CoClass(typeof(UsoSessionClass))]
        [Guid("b357f841-2130-454e-802c-5c398b549f8e")]
        public interface UsoSession : IUsoSession
        {

        }

        [ComImport]
        [CoClass(typeof(UsoSessionClass))]
        [Guid("fccc288d-b47e-41fa-970c-935ec952f4a4")]
        public interface UsoSessionCommon : IUsoSessionCommon
        {
          
        }

        [ComImport]
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("fccc288d-b47e-41fa-970c-935ec952f4a4")]
        public class UsoSessionClass : UsoSessionCommon, UsoSession
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc32(IUsoUpdateCollection p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc33(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc34(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc35(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc36(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc37(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc38(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc39(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc40(int p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc41(int p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc42(string p0, string p1, string p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc43(string p0, string p1, string p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc44(int p0, object p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc45(int p0, long p1, long p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc46();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc47(int p0, short p1, object p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc48(int p0, int p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc49(int p0, object p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc50(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc51(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc52();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc53(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc54(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc55();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc56(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc57(int p0, object p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc58(int p0, object p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc59(int p0, IUsoSettingObject p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc60(int p0, IUsoSettingArray p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc61();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc62();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc63();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc64(int p0, int p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc65(int p0, int p1, Struct_33 p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc66(IUsoUpdateCollection p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc67();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc68();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc3(Guid p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc4(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc5(Struct_24 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc6(Struct_25 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc7(int p0, IUsoUpdateCollection p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc8(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc9(Struct_5 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc10(Struct_5 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc11(Struct_5 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc12(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc13(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc14(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc15([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc16([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc17(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc18();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc19();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc20(int p0, int p1, int p2, short p3, short p4, int p5);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc21(uint p0, short p1, [MarshalAs(UnmanagedType.LPWStr)] string p2); // Proc21(short p0, short p1, wchar_t* p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc22(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc23(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc24();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc25(int p0, int p1, IUsoUpdateHistoryEntryCollection p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc26(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc27(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc28(string p0, int p1, string p2); // HRESULT Proc28(/* Stack Offset: 8 */ [In] /* C:(FC_TOP_LEVEL_CONFORMANCE)(16)(FC_ZERO)(FC_ULONG)(0) */ /* unique */wchar_t*[]* p0, /* Stack Offset: 16 */ [In] int p1, /* Stack Offset: 24 */ [In] wchar_t* p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc29(int p0, string p1, int p2); // HRESULT Proc29(/* Stack Offset: 8 */ [In] int p0, /* Stack Offset: 16 */ [Out] /* (FC_TOP_LEVEL_CONFORMANCE)(24)(FC_ZERO)(FC_ULONG)(0) */wchar_t[1]* p1, /* Stack Offset: 24 */ [In] int p2);
            [MethodImpl(MethodImplOptions.InternalCall)] 
            public virtual extern void Proc30();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc31(int p0);
        }


        [ComImport]
        [CoClass(typeof(UsoOrchestratorClass))]
        [Guid("07f3afac-7c8a-4ce7-a5e0-3d24ee8a77e0")]
        public interface UpdateSessionOrchestrator : IUpdateSessionOrchestrator
        {

        }

        [ComImport]
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("07f3afac-7c8a-4ce7-a5e0-3d24ee8a77e0")]
        public class UsoOrchestratorClass : UpdateSessionOrchestrator
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern IUpdateSessionOrchestrator CreateUpdateSession(int param_1, Guid param_2, [MarshalAs(UnmanagedType.Interface)] out IUsoSessionCommon common);  //out object common      //out object returnedComObject   // ref IntPtr pInterface  //out UsoSessionCommon pointer //out IntPtr pointer
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void GetCurrentActiveUpdateSessions(IUsoSessionCollection param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void LogTaskRunning([In, MarshalAs(UnmanagedType.LPWStr)] string param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void CreateUxUpdateManager(IUxUpdateManager param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void CreateUniversalOrchestrator(IUniversalOrchestrator param_1);
        }
        
        
        [ComImport]
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("b91d5831-b1bd-4608-8198-d72e155020f7")]
        public class UpdateSessionOrchestratorClass //: UpdateSessionOrchestrator, UsoSessionCommon
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern IUpdateSessionOrchestrator CreateUpdateSession(int param_1, Guid param_2, [MarshalAs(UnmanagedType.Interface)] out IUsoSessionCommon common);  //      //out object returnedComObject   // ref IntPtr pInterface  //out UsoSessionCommon pointer //out IntPtr pointer
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void GetCurrentActiveUpdateSessions(IUsoSessionCollection param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void LogTaskRunning([In, MarshalAs(UnmanagedType.LPWStr)] string param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void CreateUxUpdateManager(IUxUpdateManager param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void CreateUniversalOrchestrator(IUniversalOrchestrator param_1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc32(IUsoUpdateCollection p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc33(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc34(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc35(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc36(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc37(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc38(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc39(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc40(int p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc41(int p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc42(string p0, string p1, string p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc43(string p0, string p1, string p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc44(int p0, object p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc45(int p0, long p1, long p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc46();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc47(int p0, short p1, object p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc48(int p0, int p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc49(int p0, object p1, int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc50(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc51(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc52();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc53(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc54(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc55();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc56(string p0, object p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc57(int p0, object p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc58(int p0, object p1, int p2, int p3);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc59(int p0, IUsoSettingObject p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc60(int p0, IUsoSettingArray p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc61();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc62();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc63();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc64(int p0, int p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc65(int p0, int p1, Struct_33 p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc66(IUsoUpdateCollection p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc67();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc68();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc3(Guid p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc4(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc5(Struct_24 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc6(Struct_25 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc7(int p0, IUsoUpdateCollection p1);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc8(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc9(Struct_5 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc10(Struct_5 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc11(Struct_5 p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc12(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc13(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc14(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc15([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc16([MarshalAs(UnmanagedType.BStr)] string p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc17(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc18();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc19();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc20(int p0, int p1, int p2, short p3, short p4, int p5);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc21(uint p0, short p1, [MarshalAs(UnmanagedType.LPWStr)] string p2); // Proc21(short p0, short p1, wchar_t* p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc22(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc23(short p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc24();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc25(int p0, int p1, IUsoUpdateHistoryEntryCollection p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc26(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc27(int p0);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc28(string p0, int p1, string p2); // HRESULT Proc28(/* Stack Offset: 8 */ [In] /* C:(FC_TOP_LEVEL_CONFORMANCE)(16)(FC_ZERO)(FC_ULONG)(0) */ /* unique */wchar_t*[]* p0, /* Stack Offset: 16 */ [In] int p1, /* Stack Offset: 24 */ [In] wchar_t* p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc29(int p0, string p1, int p2); // HRESULT Proc29(/* Stack Offset: 8 */ [In] int p0, /* Stack Offset: 16 */ [Out] /* (FC_TOP_LEVEL_CONFORMANCE)(24)(FC_ZERO)(FC_ULONG)(0) */wchar_t[1]* p1, /* Stack Offset: 24 */ [In] int p2);
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc30();
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Proc31(int p0);
        }

    }

}