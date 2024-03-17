# JitBuddy [![Build Status](https://github.com/xoofx/JitBuddy/workflows/ci/badge.svg?branch=master)](https://github.com/xoofx/JitBuddy/actions) [![NuGet](https://img.shields.io/nuget/v/JitBuddy.svg)](https://www.nuget.org/packages/JitBuddy/)

<img align="right" width="160px" height="160px" src="img/JitBuddy.png">

JitBuddy provides a small helper method to disassemble to a x86/x64 ASM listing the native code generated by the JIT of  a managed method.

```C#
using System;
using System.Reflection;
using JitBuddy;

namespace JitBuddyExample
{
    public class Program
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        
        static void Main()
        {
            var method = typeof(Program).GetMethod("Add", BindingFlags.Public | BindingFlags.Static);
            Console.WriteLine(method.ToAsm());
        }
   }
}
```
will produce the following output:

```
00007FFD515B3FB0 lea       eax,[rcx+rdx]
00007FFD515B3FB3 ret
```

## Usage

> Starting with .NET Core 3.0 Tiered compilation is enabled and you won't get the best ASM when running this code
> In order to check the assembly, you should disable tiered compilation (that will fallback to best tiered model)
> by setting the environment variable `set COMPlus_TieredCompilation=0`

```c#
var method = ...; // Get a MethodInfo via typeof(XXX).GetMethod(...)
var asm = method.ToAsm();
```

## Caveats

- On Linux, JitBuddy only works (for now) on CoreCLR 3.0, CoreCLR 2.0-2.2 seem to not be properly supported by ClrMd: [#303](https://github.com/microsoft/clrmd/issues/303)
  
## License

This software is released under the [BSD-Clause 2 license](http://opensource.org/licenses/BSD-2-Clause). 

## Credits

JitBuddy is a one file simple wrapper of the following amazing library:

* [**`Iced`**](https://github.com/0xd4d/iced) for the disassembler part.
* [**`clrmd`** aka `Microsoft.Diagnostics.Runtime`](https://github.com/Microsoft/clrmd)

The Logo `processor` by [ibrandify](https://thenounproject.com/ibrandify) from the Noun Project

## Author

Alexandre Mutel aka [xoofx](https://xoofx.github.io).
