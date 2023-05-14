; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [262 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 72
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 101
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 96
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 86
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 86
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 53
	i32 166922606, ; 6: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 37
	i32 172012715, ; 7: FastAndroidCamera.dll => 0xa40b4ab => 6
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 87
	i32 209399409, ; 9: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 51
	i32 219130465, ; 10: Xamarin.Android.Support.v4 => 0xd0faa61 => 42
	i32 220171995, ; 11: System.Diagnostics.Debug => 0xd1f8edb => 125
	i32 230216969, ; 12: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 67
	i32 231814094, ; 13: System.Globalization => 0xdd133ce => 130
	i32 232815796, ; 14: System.Web.Services => 0xde07cb4 => 114
	i32 261689757, ; 15: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 56
	i32 278686392, ; 16: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 71
	i32 280482487, ; 17: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 65
	i32 318968648, ; 18: Xamarin.AndroidX.Activity.dll => 0x13031348 => 43
	i32 321597661, ; 19: System.Numerics => 0x132b30dd => 23
	i32 334355562, ; 20: ZXing.Net.Mobile.Forms.dll => 0x13eddc6a => 104
	i32 342366114, ; 21: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 69
	i32 385762202, ; 22: System.Memory.dll => 0x16fe439a => 22
	i32 389971796, ; 23: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 38
	i32 441335492, ; 24: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 55
	i32 442521989, ; 25: Xamarin.Essentials => 0x1a605985 => 95
	i32 442565967, ; 26: System.Collections => 0x1a61054f => 123
	i32 450948140, ; 27: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 64
	i32 465846621, ; 28: mscorlib => 0x1bc4415d => 15
	i32 469710990, ; 29: System.dll => 0x1bff388e => 20
	i32 476646585, ; 30: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 65
	i32 486930444, ; 31: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 76
	i32 498788369, ; 32: System.ObjectModel => 0x1dbae811 => 126
	i32 514659665, ; 33: Xamarin.Android.Support.Compat => 0x1ead1551 => 37
	i32 526420162, ; 34: System.Transactions.dll => 0x1f6088c2 => 108
	i32 545304856, ; 35: System.Runtime.Extensions => 0x2080b118 => 124
	i32 548916678, ; 36: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 13
	i32 605376203, ; 37: System.IO.Compression.FileSystem => 0x24154ecb => 112
	i32 618636221, ; 38: K4os.Compression.LZ4.Streams => 0x24dfa3bd => 11
	i32 627609679, ; 39: Xamarin.AndroidX.CustomView => 0x2568904f => 60
	i32 662205335, ; 40: System.Text.Encodings.Web.dll => 0x27787397 => 31
	i32 663517072, ; 41: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 92
	i32 666292255, ; 42: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 48
	i32 690569205, ; 43: System.Xml.Linq.dll => 0x29293ff5 => 34
	i32 692692150, ; 44: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 36
	i32 722857257, ; 45: System.Runtime.Loader.dll => 0x2b15ed29 => 27
	i32 775507847, ; 46: System.IO.Compression => 0x2e394f87 => 111
	i32 809851609, ; 47: System.Drawing.Common.dll => 0x30455ad9 => 110
	i32 843511501, ; 48: Xamarin.AndroidX.Print => 0x3246f6cd => 83
	i32 877678880, ; 49: System.Globalization.dll => 0x34505120 => 130
	i32 882883187, ; 50: Xamarin.Android.Support.v4.dll => 0x349fba73 => 42
	i32 928116545, ; 51: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 101
	i32 954320159, ; 52: ZXing.Net.Mobile.Forms => 0x38e1c51f => 104
	i32 958213972, ; 53: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 41
	i32 967690846, ; 54: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 69
	i32 974778368, ; 55: FormsViewGroup.dll => 0x3a19f000 => 7
	i32 983077409, ; 56: MySql.Data.dll => 0x3a989221 => 16
	i32 992768348, ; 57: System.Collections.dll => 0x3b2c715c => 123
	i32 1012816738, ; 58: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 85
	i32 1035644815, ; 59: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 47
	i32 1042160112, ; 60: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 98
	i32 1052210849, ; 61: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 73
	i32 1098259244, ; 62: System => 0x41761b2c => 20
	i32 1134191450, ; 63: ZXingNetMobile.dll => 0x439a635a => 106
	i32 1175144683, ; 64: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 90
	i32 1178241025, ; 65: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 80
	i32 1179889866, ; 66: Testro.dll => 0x4653b0ca => 35
	i32 1204270330, ; 67: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 48
	i32 1267360935, ; 68: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 91
	i32 1269851834, ; 69: BouncyCastle.Crypto => 0x4bb066ba => 5
	i32 1293217323, ; 70: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 62
	i32 1364015309, ; 71: System.IO => 0x514d38cd => 121
	i32 1365406463, ; 72: System.ServiceModel.Internals.dll => 0x516272ff => 115
	i32 1376866003, ; 73: Xamarin.AndroidX.SavedState => 0x52114ed3 => 85
	i32 1395857551, ; 74: Xamarin.AndroidX.Media.dll => 0x5333188f => 77
	i32 1406073936, ; 75: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 57
	i32 1411638395, ; 76: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 25
	i32 1445445088, ; 77: Xamarin.Android.Support.Fragment => 0x5627bde0 => 40
	i32 1457743152, ; 78: System.Runtime.Extensions.dll => 0x56e36530 => 124
	i32 1460219004, ; 79: Xamarin.Forms.Xaml => 0x57092c7c => 99
	i32 1462112819, ; 80: System.IO.Compression.dll => 0x57261233 => 111
	i32 1469204771, ; 81: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 46
	i32 1487250139, ; 82: K4os.Hash.xxHash => 0x58a5a2db => 12
	i32 1543031311, ; 83: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 129
	i32 1571005899, ; 84: zxing.portable => 0x5da3a5cb => 105
	i32 1574652163, ; 85: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 39
	i32 1582372066, ; 86: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 61
	i32 1592978981, ; 87: System.Runtime.Serialization.dll => 0x5ef2ee25 => 4
	i32 1596753216, ; 88: BouncyCastle.Crypto.dll => 0x5f2c8540 => 5
	i32 1622152042, ; 89: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 75
	i32 1624863272, ; 90: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 94
	i32 1636350590, ; 91: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 59
	i32 1639515021, ; 92: System.Net.Http.dll => 0x61b9038d => 3
	i32 1639986890, ; 93: System.Text.RegularExpressions => 0x61c036ca => 129
	i32 1657153582, ; 94: System.Runtime => 0x62c6282e => 26
	i32 1658241508, ; 95: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 88
	i32 1658251792, ; 96: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 100
	i32 1670060433, ; 97: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 56
	i32 1701541528, ; 98: System.Diagnostics.Debug.dll => 0x656b7698 => 125
	i32 1726116996, ; 99: System.Reflection.dll => 0x66e27484 => 120
	i32 1729485958, ; 100: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 52
	i32 1746115085, ; 101: System.IO.Pipelines.dll => 0x68139a0d => 21
	i32 1766324549, ; 102: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 87
	i32 1776026572, ; 103: System.Core.dll => 0x69dc03cc => 19
	i32 1788241197, ; 104: Xamarin.AndroidX.Fragment => 0x6a96652d => 64
	i32 1796167890, ; 105: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 13
	i32 1808609942, ; 106: Xamarin.AndroidX.Loader => 0x6bcd3296 => 75
	i32 1813201214, ; 107: Xamarin.Google.Android.Material => 0x6c13413e => 100
	i32 1818569960, ; 108: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 81
	i32 1867746548, ; 109: Xamarin.Essentials.dll => 0x6f538cf4 => 95
	i32 1878053835, ; 110: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 99
	i32 1885316902, ; 111: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 49
	i32 1904184254, ; 112: FastAndroidCamera => 0x717f8bbe => 6
	i32 1919157823, ; 113: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 78
	i32 1925302748, ; 114: K4os.Compression.LZ4.dll => 0x72c1c9dc => 10
	i32 2011961780, ; 115: System.Buffers.dll => 0x77ec19b4 => 17
	i32 2019465201, ; 116: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 73
	i32 2052258152, ; 117: Testro.Android.dll => 0x7a52f968 => 0
	i32 2055257422, ; 118: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 70
	i32 2079903147, ; 119: System.Runtime.dll => 0x7bf8cdab => 26
	i32 2090596640, ; 120: System.Numerics.Vectors => 0x7c9bf920 => 24
	i32 2097448633, ; 121: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 66
	i32 2126786730, ; 122: Xamarin.Forms.Platform.Android => 0x7ec430aa => 97
	i32 2166116741, ; 123: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 39
	i32 2193016926, ; 124: System.ObjectModel.dll => 0x82b6c85e => 126
	i32 2201231467, ; 125: System.Net.Http => 0x8334206b => 3
	i32 2217644978, ; 126: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 90
	i32 2244775296, ; 127: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 76
	i32 2256548716, ; 128: Xamarin.AndroidX.MultiDex => 0x8680336c => 78
	i32 2261435625, ; 129: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 68
	i32 2265110946, ; 130: System.Security.AccessControl.dll => 0x8702d9a2 => 28
	i32 2279755925, ; 131: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 84
	i32 2315684594, ; 132: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 44
	i32 2329204181, ; 133: zxing.portable.dll => 0x8ad4d5d5 => 105
	i32 2330457430, ; 134: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 38
	i32 2341995103, ; 135: ZXingNetMobile => 0x8b98025f => 106
	i32 2373288475, ; 136: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 40
	i32 2383496789, ; 137: System.Security.Principal.Windows.dll => 0x8e114655 => 30
	i32 2409053734, ; 138: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 82
	i32 2431243866, ; 139: ZXing.Net.Mobile.Core.dll => 0x90e9d65a => 102
	i32 2454642406, ; 140: System.Text.Encoding.dll => 0x924edee6 => 128
	i32 2465532216, ; 141: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 55
	i32 2468283051, ; 142: Testro => 0x931f02ab => 35
	i32 2471841756, ; 143: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 144: Java.Interop.dll => 0x93918882 => 9
	i32 2482213323, ; 145: ZXing.Net.Mobile.Forms.Android => 0x93f391cb => 103
	i32 2486824558, ; 146: K4os.Hash.xxHash.dll => 0x9439ee6e => 12
	i32 2501346920, ; 147: System.Data.DataSetExtensions => 0x95178668 => 109
	i32 2505896520, ; 148: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 72
	i32 2570120770, ; 149: System.Text.Encodings.Web => 0x9930ee42 => 31
	i32 2581819634, ; 150: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 91
	i32 2620871830, ; 151: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 59
	i32 2624644809, ; 152: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 63
	i32 2633051222, ; 153: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 71
	i32 2660759594, ; 154: System.Security.Cryptography.ProtectedData.dll => 0x9e97f82a => 116
	i32 2663698177, ; 155: System.Runtime.Loader => 0x9ec4cf01 => 27
	i32 2693849962, ; 156: System.IO.dll => 0xa090e36a => 121
	i32 2701096212, ; 157: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 88
	i32 2715334215, ; 158: System.Threading.Tasks.dll => 0xa1d8b647 => 122
	i32 2732626843, ; 159: Xamarin.AndroidX.Activity => 0xa2e0939b => 43
	i32 2737747696, ; 160: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 46
	i32 2765824710, ; 161: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 2
	i32 2766581644, ; 162: Xamarin.Forms.Core => 0xa4e6af8c => 96
	i32 2778768386, ; 163: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 93
	i32 2810250172, ; 164: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 57
	i32 2819470561, ; 165: System.Xml.dll => 0xa80db4e1 => 33
	i32 2841355853, ; 166: System.Security.Permissions => 0xa95ba64d => 29
	i32 2853208004, ; 167: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 93
	i32 2855708567, ; 168: Xamarin.AndroidX.Transition => 0xaa36a797 => 89
	i32 2867946736, ; 169: System.Security.Cryptography.ProtectedData => 0xaaf164f0 => 116
	i32 2901442782, ; 170: System.Reflection => 0xacf080de => 120
	i32 2903344695, ; 171: System.ComponentModel.Composition => 0xad0d8637 => 113
	i32 2905242038, ; 172: mscorlib.dll => 0xad2a79b6 => 15
	i32 2916838712, ; 173: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 94
	i32 2919462931, ; 174: System.Numerics.Vectors.dll => 0xae037813 => 24
	i32 2921128767, ; 175: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 45
	i32 2944313911, ; 176: System.Configuration.ConfigurationManager.dll => 0xaf7eaa37 => 18
	i32 2968338931, ; 177: System.Security.Principal.Windows => 0xb0ed41f3 => 30
	i32 2978675010, ; 178: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 62
	i32 3012788804, ; 179: System.Configuration.ConfigurationManager => 0xb3938244 => 18
	i32 3024354802, ; 180: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 67
	i32 3025069135, ; 181: K4os.Compression.LZ4.Streams.dll => 0xb44ee44f => 11
	i32 3044182254, ; 182: FormsViewGroup => 0xb57288ee => 7
	i32 3057625584, ; 183: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 79
	i32 3075834255, ; 184: System.Threading.Tasks => 0xb755818f => 122
	i32 3092211740, ; 185: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 41
	i32 3111772706, ; 186: System.Runtime.Serialization => 0xb979e222 => 4
	i32 3124832203, ; 187: System.Threading.Tasks.Extensions => 0xba4127cb => 119
	i32 3132293585, ; 188: System.Security.AccessControl => 0xbab301d1 => 28
	i32 3204380047, ; 189: System.Data.dll => 0xbefef58f => 107
	i32 3211777861, ; 190: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 61
	i32 3213246214, ; 191: System.Security.Permissions.dll => 0xbf863f06 => 29
	i32 3220365878, ; 192: System.Threading => 0xbff2e236 => 127
	i32 3247949154, ; 193: Mono.Security => 0xc197c562 => 118
	i32 3258312781, ; 194: Xamarin.AndroidX.CardView => 0xc235e84d => 52
	i32 3265893370, ; 195: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 119
	i32 3267021929, ; 196: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 50
	i32 3299363146, ; 197: System.Text.Encoding => 0xc4a8494a => 128
	i32 3317135071, ; 198: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 60
	i32 3317144872, ; 199: System.Data => 0xc5b79d28 => 107
	i32 3340431453, ; 200: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 49
	i32 3346324047, ; 201: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 80
	i32 3353484488, ; 202: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 66
	i32 3358260929, ; 203: System.Text.Json => 0xc82afec1 => 32
	i32 3362522851, ; 204: Xamarin.AndroidX.Core => 0xc86c06e3 => 58
	i32 3366347497, ; 205: Java.Interop => 0xc8a662e9 => 9
	i32 3374999561, ; 206: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 84
	i32 3381033598, ; 207: K4os.Compression.LZ4 => 0xc9867a7e => 10
	i32 3395150330, ; 208: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 25
	i32 3404865022, ; 209: System.ServiceModel.Internals => 0xcaf21dfe => 115
	i32 3429136800, ; 210: System.Xml => 0xcc6479a0 => 33
	i32 3430777524, ; 211: netstandard => 0xcc7d82b4 => 1
	i32 3439690031, ; 212: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 36
	i32 3441283291, ; 213: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 63
	i32 3467345667, ; 214: MySql.Data => 0xceab7f03 => 16
	i32 3476120550, ; 215: Mono.Android => 0xcf3163e6 => 14
	i32 3485117614, ; 216: System.Text.Json.dll => 0xcfbaacae => 32
	i32 3486566296, ; 217: System.Transactions => 0xcfd0c798 => 108
	i32 3493954962, ; 218: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 54
	i32 3499097210, ; 219: Google.Protobuf.dll => 0xd08ffc7a => 8
	i32 3501239056, ; 220: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 50
	i32 3509114376, ; 221: System.Xml.Linq => 0xd128d608 => 34
	i32 3515174580, ; 222: System.Security.dll => 0xd1854eb4 => 117
	i32 3536029504, ; 223: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 97
	i32 3567349600, ; 224: System.ComponentModel.Composition.dll => 0xd4a16f60 => 113
	i32 3618140916, ; 225: Xamarin.AndroidX.Preference => 0xd7a872f4 => 82
	i32 3627220390, ; 226: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 83
	i32 3632359727, ; 227: Xamarin.Forms.Platform => 0xd881692f => 98
	i32 3633644679, ; 228: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 45
	i32 3641597786, ; 229: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 70
	i32 3645630983, ; 230: Google.Protobuf => 0xd94bea07 => 8
	i32 3672681054, ; 231: Mono.Android.dll => 0xdae8aa5e => 14
	i32 3676310014, ; 232: System.Web.Services.dll => 0xdb2009fe => 114
	i32 3682565725, ; 233: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 51
	i32 3684561358, ; 234: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 54
	i32 3689375977, ; 235: System.Drawing.Common => 0xdbe768e9 => 110
	i32 3718780102, ; 236: Xamarin.AndroidX.Annotation => 0xdda814c6 => 44
	i32 3724971120, ; 237: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 79
	i32 3758932259, ; 238: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 68
	i32 3786282454, ; 239: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 53
	i32 3822602673, ; 240: Xamarin.AndroidX.Media => 0xe3d849b1 => 77
	i32 3829621856, ; 241: System.Numerics.dll => 0xe4436460 => 23
	i32 3847036339, ; 242: ZXing.Net.Mobile.Forms.Android.dll => 0xe54d1db3 => 103
	i32 3885922214, ; 243: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 89
	i32 3896760992, ; 244: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 58
	i32 3920810846, ; 245: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 112
	i32 3921031405, ; 246: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 92
	i32 3931092270, ; 247: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 81
	i32 3945713374, ; 248: System.Data.DataSetExtensions.dll => 0xeb2ecede => 109
	i32 3953953790, ; 249: System.Text.Encoding.CodePages => 0xebac8bfe => 2
	i32 3955647286, ; 250: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 47
	i32 4023392905, ; 251: System.IO.Pipelines => 0xefd01a89 => 21
	i32 4025784931, ; 252: System.Memory => 0xeff49a63 => 22
	i32 4073602200, ; 253: System.Threading.dll => 0xf2ce3c98 => 127
	i32 4105002889, ; 254: Mono.Security.dll => 0xf4ad5f89 => 118
	i32 4133189258, ; 255: Testro.Android => 0xf65b768a => 0
	i32 4151237749, ; 256: System.Core => 0xf76edc75 => 19
	i32 4182413190, ; 257: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 74
	i32 4185676441, ; 258: System.Security => 0xf97c5a99 => 117
	i32 4186595366, ; 259: ZXing.Net.Mobile.Core => 0xf98a6026 => 102
	i32 4260525087, ; 260: System.Buffers => 0xfdf2741f => 17
	i32 4292120959 ; 261: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 74
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [262 x i32] [
	i32 72, i32 101, i32 96, i32 86, i32 86, i32 53, i32 37, i32 6, ; 0..7
	i32 87, i32 51, i32 42, i32 125, i32 67, i32 130, i32 114, i32 56, ; 8..15
	i32 71, i32 65, i32 43, i32 23, i32 104, i32 69, i32 22, i32 38, ; 16..23
	i32 55, i32 95, i32 123, i32 64, i32 15, i32 20, i32 65, i32 76, ; 24..31
	i32 126, i32 37, i32 108, i32 124, i32 13, i32 112, i32 11, i32 60, ; 32..39
	i32 31, i32 92, i32 48, i32 34, i32 36, i32 27, i32 111, i32 110, ; 40..47
	i32 83, i32 130, i32 42, i32 101, i32 104, i32 41, i32 69, i32 7, ; 48..55
	i32 16, i32 123, i32 85, i32 47, i32 98, i32 73, i32 20, i32 106, ; 56..63
	i32 90, i32 80, i32 35, i32 48, i32 91, i32 5, i32 62, i32 121, ; 64..71
	i32 115, i32 85, i32 77, i32 57, i32 25, i32 40, i32 124, i32 99, ; 72..79
	i32 111, i32 46, i32 12, i32 129, i32 105, i32 39, i32 61, i32 4, ; 80..87
	i32 5, i32 75, i32 94, i32 59, i32 3, i32 129, i32 26, i32 88, ; 88..95
	i32 100, i32 56, i32 125, i32 120, i32 52, i32 21, i32 87, i32 19, ; 96..103
	i32 64, i32 13, i32 75, i32 100, i32 81, i32 95, i32 99, i32 49, ; 104..111
	i32 6, i32 78, i32 10, i32 17, i32 73, i32 0, i32 70, i32 26, ; 112..119
	i32 24, i32 66, i32 97, i32 39, i32 126, i32 3, i32 90, i32 76, ; 120..127
	i32 78, i32 68, i32 28, i32 84, i32 44, i32 105, i32 38, i32 106, ; 128..135
	i32 40, i32 30, i32 82, i32 102, i32 128, i32 55, i32 35, i32 1, ; 136..143
	i32 9, i32 103, i32 12, i32 109, i32 72, i32 31, i32 91, i32 59, ; 144..151
	i32 63, i32 71, i32 116, i32 27, i32 121, i32 88, i32 122, i32 43, ; 152..159
	i32 46, i32 2, i32 96, i32 93, i32 57, i32 33, i32 29, i32 93, ; 160..167
	i32 89, i32 116, i32 120, i32 113, i32 15, i32 94, i32 24, i32 45, ; 168..175
	i32 18, i32 30, i32 62, i32 18, i32 67, i32 11, i32 7, i32 79, ; 176..183
	i32 122, i32 41, i32 4, i32 119, i32 28, i32 107, i32 61, i32 29, ; 184..191
	i32 127, i32 118, i32 52, i32 119, i32 50, i32 128, i32 60, i32 107, ; 192..199
	i32 49, i32 80, i32 66, i32 32, i32 58, i32 9, i32 84, i32 10, ; 200..207
	i32 25, i32 115, i32 33, i32 1, i32 36, i32 63, i32 16, i32 14, ; 208..215
	i32 32, i32 108, i32 54, i32 8, i32 50, i32 34, i32 117, i32 97, ; 216..223
	i32 113, i32 82, i32 83, i32 98, i32 45, i32 70, i32 8, i32 14, ; 224..231
	i32 114, i32 51, i32 54, i32 110, i32 44, i32 79, i32 68, i32 53, ; 232..239
	i32 77, i32 23, i32 103, i32 89, i32 58, i32 112, i32 92, i32 81, ; 240..247
	i32 109, i32 2, i32 47, i32 21, i32 22, i32 127, i32 118, i32 0, ; 248..255
	i32 19, i32 74, i32 117, i32 102, i32 17, i32 74 ; 256..261
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
