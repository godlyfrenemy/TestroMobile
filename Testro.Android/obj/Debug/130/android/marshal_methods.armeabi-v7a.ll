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
@assembly_image_cache_hashes = local_unnamed_addr constant [228 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 59
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 88
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 83
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 73
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 73
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 40
	i32 166922606, ; 6: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 24
	i32 172012715, ; 7: FastAndroidCamera.dll => 0xa40b4ab => 4
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 74
	i32 209399409, ; 9: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 38
	i32 219130465, ; 10: Xamarin.Android.Support.v4 => 0xd0faa61 => 29
	i32 220171995, ; 11: System.Diagnostics.Debug => 0xd1f8edb => 107
	i32 230216969, ; 12: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 54
	i32 231814094, ; 13: System.Globalization => 0xdd133ce => 113
	i32 232815796, ; 14: System.Web.Services => 0xde07cb4 => 101
	i32 261689757, ; 15: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 43
	i32 278686392, ; 16: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 58
	i32 280482487, ; 17: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 52
	i32 318968648, ; 18: Xamarin.AndroidX.Activity.dll => 0x13031348 => 30
	i32 321597661, ; 19: System.Numerics => 0x132b30dd => 16
	i32 334355562, ; 20: ZXing.Net.Mobile.Forms.dll => 0x13eddc6a => 91
	i32 342366114, ; 21: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 56
	i32 385762202, ; 22: System.Memory.dll => 0x16fe439a => 15
	i32 389971796, ; 23: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 25
	i32 441335492, ; 24: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 42
	i32 442521989, ; 25: Xamarin.Essentials => 0x1a605985 => 82
	i32 442565967, ; 26: System.Collections => 0x1a61054f => 105
	i32 450948140, ; 27: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 51
	i32 465846621, ; 28: mscorlib => 0x1bc4415d => 8
	i32 469710990, ; 29: System.dll => 0x1bff388e => 14
	i32 476646585, ; 30: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 52
	i32 486930444, ; 31: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 63
	i32 498788369, ; 32: System.ObjectModel => 0x1dbae811 => 108
	i32 514659665, ; 33: Xamarin.Android.Support.Compat => 0x1ead1551 => 24
	i32 526420162, ; 34: System.Transactions.dll => 0x1f6088c2 => 95
	i32 545304856, ; 35: System.Runtime.Extensions => 0x2080b118 => 106
	i32 605376203, ; 36: System.IO.Compression.FileSystem => 0x24154ecb => 99
	i32 627609679, ; 37: Xamarin.AndroidX.CustomView => 0x2568904f => 47
	i32 663517072, ; 38: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 79
	i32 666292255, ; 39: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 35
	i32 690569205, ; 40: System.Xml.Linq.dll => 0x29293ff5 => 21
	i32 692692150, ; 41: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 23
	i32 775507847, ; 42: System.IO.Compression => 0x2e394f87 => 98
	i32 809851609, ; 43: System.Drawing.Common.dll => 0x30455ad9 => 97
	i32 843511501, ; 44: Xamarin.AndroidX.Print => 0x3246f6cd => 70
	i32 877678880, ; 45: System.Globalization.dll => 0x34505120 => 113
	i32 882883187, ; 46: Xamarin.Android.Support.v4.dll => 0x349fba73 => 29
	i32 928116545, ; 47: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 88
	i32 954320159, ; 48: ZXing.Net.Mobile.Forms => 0x38e1c51f => 91
	i32 958213972, ; 49: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 28
	i32 967690846, ; 50: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 56
	i32 974778368, ; 51: FormsViewGroup.dll => 0x3a19f000 => 5
	i32 992768348, ; 52: System.Collections.dll => 0x3b2c715c => 105
	i32 1012816738, ; 53: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 72
	i32 1035644815, ; 54: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 34
	i32 1042160112, ; 55: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 85
	i32 1052210849, ; 56: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 60
	i32 1098259244, ; 57: System => 0x41761b2c => 14
	i32 1134191450, ; 58: ZXingNetMobile.dll => 0x439a635a => 93
	i32 1175144683, ; 59: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 77
	i32 1178241025, ; 60: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 67
	i32 1179889866, ; 61: Testro.dll => 0x4653b0ca => 22
	i32 1204270330, ; 62: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 35
	i32 1267360935, ; 63: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 78
	i32 1293217323, ; 64: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 49
	i32 1364015309, ; 65: System.IO => 0x514d38cd => 111
	i32 1365406463, ; 66: System.ServiceModel.Internals.dll => 0x516272ff => 102
	i32 1376866003, ; 67: Xamarin.AndroidX.SavedState => 0x52114ed3 => 72
	i32 1395857551, ; 68: Xamarin.AndroidX.Media.dll => 0x5333188f => 64
	i32 1406073936, ; 69: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 44
	i32 1411638395, ; 70: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 18
	i32 1445445088, ; 71: Xamarin.Android.Support.Fragment => 0x5627bde0 => 27
	i32 1457743152, ; 72: System.Runtime.Extensions.dll => 0x56e36530 => 106
	i32 1460219004, ; 73: Xamarin.Forms.Xaml => 0x57092c7c => 86
	i32 1462112819, ; 74: System.IO.Compression.dll => 0x57261233 => 98
	i32 1469204771, ; 75: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 33
	i32 1511525525, ; 76: MySqlConnector => 0x5a180c95 => 9
	i32 1543031311, ; 77: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 112
	i32 1571005899, ; 78: zxing.portable => 0x5da3a5cb => 92
	i32 1574652163, ; 79: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 26
	i32 1582372066, ; 80: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 48
	i32 1592978981, ; 81: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1622152042, ; 82: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 62
	i32 1624863272, ; 83: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 81
	i32 1636350590, ; 84: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 46
	i32 1639515021, ; 85: System.Net.Http.dll => 0x61b9038d => 2
	i32 1639986890, ; 86: System.Text.RegularExpressions => 0x61c036ca => 112
	i32 1657153582, ; 87: System.Runtime => 0x62c6282e => 19
	i32 1658241508, ; 88: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 75
	i32 1658251792, ; 89: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 87
	i32 1670060433, ; 90: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 43
	i32 1701541528, ; 91: System.Diagnostics.Debug.dll => 0x656b7698 => 107
	i32 1729485958, ; 92: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 39
	i32 1766324549, ; 93: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 74
	i32 1776026572, ; 94: System.Core.dll => 0x69dc03cc => 12
	i32 1788241197, ; 95: Xamarin.AndroidX.Fragment => 0x6a96652d => 51
	i32 1808609942, ; 96: Xamarin.AndroidX.Loader => 0x6bcd3296 => 62
	i32 1813201214, ; 97: Xamarin.Google.Android.Material => 0x6c13413e => 87
	i32 1818569960, ; 98: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 68
	i32 1867746548, ; 99: Xamarin.Essentials.dll => 0x6f538cf4 => 82
	i32 1878053835, ; 100: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 86
	i32 1885316902, ; 101: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 36
	i32 1904184254, ; 102: FastAndroidCamera => 0x717f8bbe => 4
	i32 1919157823, ; 103: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 65
	i32 2011961780, ; 104: System.Buffers.dll => 0x77ec19b4 => 11
	i32 2019465201, ; 105: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 60
	i32 2046015958, ; 106: Naxam.TopTabbedPage.Forms => 0x79f3b9d6 => 10
	i32 2052258152, ; 107: Testro.Android.dll => 0x7a52f968 => 0
	i32 2055257422, ; 108: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 57
	i32 2079903147, ; 109: System.Runtime.dll => 0x7bf8cdab => 19
	i32 2090596640, ; 110: System.Numerics.Vectors => 0x7c9bf920 => 17
	i32 2097448633, ; 111: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 53
	i32 2126786730, ; 112: Xamarin.Forms.Platform.Android => 0x7ec430aa => 84
	i32 2166116741, ; 113: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 26
	i32 2193016926, ; 114: System.ObjectModel.dll => 0x82b6c85e => 108
	i32 2201231467, ; 115: System.Net.Http => 0x8334206b => 2
	i32 2217644978, ; 116: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 77
	i32 2244775296, ; 117: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 63
	i32 2256548716, ; 118: Xamarin.AndroidX.MultiDex => 0x8680336c => 65
	i32 2261435625, ; 119: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 55
	i32 2279755925, ; 120: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 71
	i32 2315684594, ; 121: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 31
	i32 2329204181, ; 122: zxing.portable.dll => 0x8ad4d5d5 => 92
	i32 2330457430, ; 123: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 25
	i32 2341995103, ; 124: ZXingNetMobile => 0x8b98025f => 93
	i32 2373288475, ; 125: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 27
	i32 2409053734, ; 126: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 69
	i32 2431243866, ; 127: ZXing.Net.Mobile.Core.dll => 0x90e9d65a => 89
	i32 2454642406, ; 128: System.Text.Encoding.dll => 0x924edee6 => 110
	i32 2465532216, ; 129: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 42
	i32 2468283051, ; 130: Testro => 0x931f02ab => 22
	i32 2471841756, ; 131: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 132: Java.Interop.dll => 0x93918882 => 6
	i32 2482213323, ; 133: ZXing.Net.Mobile.Forms.Android => 0x93f391cb => 90
	i32 2501346920, ; 134: System.Data.DataSetExtensions => 0x95178668 => 96
	i32 2505896520, ; 135: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 59
	i32 2581819634, ; 136: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 78
	i32 2620871830, ; 137: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 46
	i32 2624644809, ; 138: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 50
	i32 2633051222, ; 139: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 58
	i32 2693849962, ; 140: System.IO.dll => 0xa090e36a => 111
	i32 2701096212, ; 141: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 75
	i32 2715334215, ; 142: System.Threading.Tasks.dll => 0xa1d8b647 => 104
	i32 2732626843, ; 143: Xamarin.AndroidX.Activity => 0xa2e0939b => 30
	i32 2737747696, ; 144: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 33
	i32 2766581644, ; 145: Xamarin.Forms.Core => 0xa4e6af8c => 83
	i32 2778768386, ; 146: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 80
	i32 2810250172, ; 147: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 44
	i32 2819470561, ; 148: System.Xml.dll => 0xa80db4e1 => 20
	i32 2853208004, ; 149: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 80
	i32 2855708567, ; 150: Xamarin.AndroidX.Transition => 0xaa36a797 => 76
	i32 2903344695, ; 151: System.ComponentModel.Composition => 0xad0d8637 => 100
	i32 2905242038, ; 152: mscorlib.dll => 0xad2a79b6 => 8
	i32 2916838712, ; 153: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 81
	i32 2919462931, ; 154: System.Numerics.Vectors.dll => 0xae037813 => 17
	i32 2921128767, ; 155: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 32
	i32 2978675010, ; 156: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 49
	i32 3024354802, ; 157: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 54
	i32 3044182254, ; 158: FormsViewGroup => 0xb57288ee => 5
	i32 3057625584, ; 159: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 66
	i32 3075834255, ; 160: System.Threading.Tasks => 0xb755818f => 104
	i32 3092211740, ; 161: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 28
	i32 3111772706, ; 162: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3204380047, ; 163: System.Data.dll => 0xbefef58f => 94
	i32 3211777861, ; 164: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 48
	i32 3220365878, ; 165: System.Threading => 0xbff2e236 => 109
	i32 3247949154, ; 166: Mono.Security => 0xc197c562 => 103
	i32 3258312781, ; 167: Xamarin.AndroidX.CardView => 0xc235e84d => 39
	i32 3267021929, ; 168: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 37
	i32 3299363146, ; 169: System.Text.Encoding => 0xc4a8494a => 110
	i32 3317135071, ; 170: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 47
	i32 3317144872, ; 171: System.Data => 0xc5b79d28 => 94
	i32 3340431453, ; 172: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 36
	i32 3346324047, ; 173: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 67
	i32 3353484488, ; 174: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 53
	i32 3362522851, ; 175: Xamarin.AndroidX.Core => 0xc86c06e3 => 45
	i32 3366347497, ; 176: Java.Interop => 0xc8a662e9 => 6
	i32 3374999561, ; 177: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 71
	i32 3395150330, ; 178: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 18
	i32 3404865022, ; 179: System.ServiceModel.Internals => 0xcaf21dfe => 102
	i32 3429136800, ; 180: System.Xml => 0xcc6479a0 => 20
	i32 3430777524, ; 181: netstandard => 0xcc7d82b4 => 1
	i32 3439690031, ; 182: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 23
	i32 3441283291, ; 183: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 50
	i32 3476120550, ; 184: Mono.Android => 0xcf3163e6 => 7
	i32 3486566296, ; 185: System.Transactions => 0xcfd0c798 => 95
	i32 3493954962, ; 186: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 41
	i32 3501239056, ; 187: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 37
	i32 3509114376, ; 188: System.Xml.Linq => 0xd128d608 => 21
	i32 3536029504, ; 189: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 84
	i32 3567349600, ; 190: System.ComponentModel.Composition.dll => 0xd4a16f60 => 100
	i32 3618140916, ; 191: Xamarin.AndroidX.Preference => 0xd7a872f4 => 69
	i32 3627220390, ; 192: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 70
	i32 3632359727, ; 193: Xamarin.Forms.Platform => 0xd881692f => 85
	i32 3633644679, ; 194: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 32
	i32 3641597786, ; 195: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 57
	i32 3672681054, ; 196: Mono.Android.dll => 0xdae8aa5e => 7
	i32 3676310014, ; 197: System.Web.Services.dll => 0xdb2009fe => 101
	i32 3682565725, ; 198: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 38
	i32 3684561358, ; 199: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 41
	i32 3689375977, ; 200: System.Drawing.Common => 0xdbe768e9 => 97
	i32 3718780102, ; 201: Xamarin.AndroidX.Annotation => 0xdda814c6 => 31
	i32 3724971120, ; 202: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 66
	i32 3748608112, ; 203: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 13
	i32 3758932259, ; 204: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 55
	i32 3786282454, ; 205: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 40
	i32 3795705828, ; 206: Naxam.TopTabbedPage.Forms.dll => 0xe23ddfe4 => 10
	i32 3822602673, ; 207: Xamarin.AndroidX.Media => 0xe3d849b1 => 64
	i32 3829621856, ; 208: System.Numerics.dll => 0xe4436460 => 16
	i32 3847036339, ; 209: ZXing.Net.Mobile.Forms.Android.dll => 0xe54d1db3 => 90
	i32 3885922214, ; 210: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 76
	i32 3896760992, ; 211: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 45
	i32 3920810846, ; 212: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 99
	i32 3921031405, ; 213: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 79
	i32 3931092270, ; 214: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 68
	i32 3945713374, ; 215: System.Data.DataSetExtensions.dll => 0xeb2ecede => 96
	i32 3955647286, ; 216: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 34
	i32 4025784931, ; 217: System.Memory => 0xeff49a63 => 15
	i32 4073602200, ; 218: System.Threading.dll => 0xf2ce3c98 => 109
	i32 4079385022, ; 219: MySqlConnector.dll => 0xf32679be => 9
	i32 4105002889, ; 220: Mono.Security.dll => 0xf4ad5f89 => 103
	i32 4133189258, ; 221: Testro.Android => 0xf65b768a => 0
	i32 4151237749, ; 222: System.Core => 0xf76edc75 => 12
	i32 4182413190, ; 223: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 61
	i32 4186595366, ; 224: ZXing.Net.Mobile.Core => 0xf98a6026 => 89
	i32 4213026141, ; 225: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 13
	i32 4260525087, ; 226: System.Buffers => 0xfdf2741f => 11
	i32 4292120959 ; 227: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 61
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [228 x i32] [
	i32 59, i32 88, i32 83, i32 73, i32 73, i32 40, i32 24, i32 4, ; 0..7
	i32 74, i32 38, i32 29, i32 107, i32 54, i32 113, i32 101, i32 43, ; 8..15
	i32 58, i32 52, i32 30, i32 16, i32 91, i32 56, i32 15, i32 25, ; 16..23
	i32 42, i32 82, i32 105, i32 51, i32 8, i32 14, i32 52, i32 63, ; 24..31
	i32 108, i32 24, i32 95, i32 106, i32 99, i32 47, i32 79, i32 35, ; 32..39
	i32 21, i32 23, i32 98, i32 97, i32 70, i32 113, i32 29, i32 88, ; 40..47
	i32 91, i32 28, i32 56, i32 5, i32 105, i32 72, i32 34, i32 85, ; 48..55
	i32 60, i32 14, i32 93, i32 77, i32 67, i32 22, i32 35, i32 78, ; 56..63
	i32 49, i32 111, i32 102, i32 72, i32 64, i32 44, i32 18, i32 27, ; 64..71
	i32 106, i32 86, i32 98, i32 33, i32 9, i32 112, i32 92, i32 26, ; 72..79
	i32 48, i32 3, i32 62, i32 81, i32 46, i32 2, i32 112, i32 19, ; 80..87
	i32 75, i32 87, i32 43, i32 107, i32 39, i32 74, i32 12, i32 51, ; 88..95
	i32 62, i32 87, i32 68, i32 82, i32 86, i32 36, i32 4, i32 65, ; 96..103
	i32 11, i32 60, i32 10, i32 0, i32 57, i32 19, i32 17, i32 53, ; 104..111
	i32 84, i32 26, i32 108, i32 2, i32 77, i32 63, i32 65, i32 55, ; 112..119
	i32 71, i32 31, i32 92, i32 25, i32 93, i32 27, i32 69, i32 89, ; 120..127
	i32 110, i32 42, i32 22, i32 1, i32 6, i32 90, i32 96, i32 59, ; 128..135
	i32 78, i32 46, i32 50, i32 58, i32 111, i32 75, i32 104, i32 30, ; 136..143
	i32 33, i32 83, i32 80, i32 44, i32 20, i32 80, i32 76, i32 100, ; 144..151
	i32 8, i32 81, i32 17, i32 32, i32 49, i32 54, i32 5, i32 66, ; 152..159
	i32 104, i32 28, i32 3, i32 94, i32 48, i32 109, i32 103, i32 39, ; 160..167
	i32 37, i32 110, i32 47, i32 94, i32 36, i32 67, i32 53, i32 45, ; 168..175
	i32 6, i32 71, i32 18, i32 102, i32 20, i32 1, i32 23, i32 50, ; 176..183
	i32 7, i32 95, i32 41, i32 37, i32 21, i32 84, i32 100, i32 69, ; 184..191
	i32 70, i32 85, i32 32, i32 57, i32 7, i32 101, i32 38, i32 41, ; 192..199
	i32 97, i32 31, i32 66, i32 13, i32 55, i32 40, i32 10, i32 64, ; 200..207
	i32 16, i32 90, i32 76, i32 45, i32 99, i32 79, i32 68, i32 96, ; 208..215
	i32 34, i32 15, i32 109, i32 9, i32 103, i32 0, i32 12, i32 61, ; 216..223
	i32 89, i32 13, i32 11, i32 61 ; 224..227
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
