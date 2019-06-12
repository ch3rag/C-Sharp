
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.17929
//  Copyright (c) Microsoft Corporation.  All rights reserved.

// Metadata version: v4.0.30319

// Referenced Libraries
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}

// adding System.Windows.Forms reference
.assembly extern System.Windows.Forms {
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89)
  .ver 4:0:0:0
}
.assembly HelloCIL
{
  // Target Framework Attribute Data
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module HelloCIL.exe
// MVID: {BE046D4B-3BAC-42A1-B91B-A6384AACE3BC}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00730000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Program
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main(string[] args) cil managed
    {
    // Mark this method as entry point of the application
    .entrypoint  // Code size       19 (0x13)
    .maxstack  8
    // IL_XXX are code lables and can be any value, modified to be more descriptive.
    // These lables are optional are can be removed. 
    // They are useful when using looping and branching statement to direct the flow of the program.
    // Create a message box and display the string
    ldstr "CIL is way cool"
    call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string)
    
    pop
    ret
  } // end of method Program::Main

  // Default Constructor
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    // Load current object's reference
    IL_0000:  ldarg.0
    // call base class constructor
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Program::.ctor

} // end of class Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file D:\Study\Github\C#\c-sharp\Notes\16. Understanding CIL and the Role Of Dynamic Assemblies\HelloProgram.res
