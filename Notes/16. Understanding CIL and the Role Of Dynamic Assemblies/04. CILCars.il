
.assembly extern mscorlib {
    .publickeytoken = (B7 7A 5C 56 19 34 E0 89)
    .ver 4:0:0:0
}

.assembly extern System.Windows.Forms {
    .publickeytoken = (B7 7A 5C 56 19 34 E0 89)
    .ver 4:0:0:0
}

.assembly CILCars {
    .hash algorithm 0x00008004
    .ver 1:0:0:0
}
.module CILCars.dll

.namespace CILCars {
    .class public auto ansi beforefieldinit CILCar extends [mscorlib]System.Object {
        .field public string petName
        .field public int32 currSpeed


        .method public hidebysig specialname rtspecialname instance void .ctor(string name, int32 speed) cil managed {
            .maxstack 8
            ldarg.0         // load "this" onto stack
            call instance void [mscorlib]System.Object::.ctor()

            ldarg.0
            ldarg.1
            // store the top most value on the stack in field 
            stfld string CILCars.CILCar::petName

            ldarg.0
            ldarg.2
            
            stfld int32 CILCars.CILCar::currSpeed
            ret
        }
    }

    .class public auto ansi beforefieldinit CILCarInfo extends [mscorlib]System.Object {
        .method public hidebysig static void Display(class CILCars.CILCar car) cil managed {
            .maxstack 8
            .locals init ([0] string caption)

            ldstr "{0}'s speed is:"
            ldarg.0
            
            ldfld string CILCars.CILCar::petName
            call string [mscorlib]System.String::Format(string, object)

            stloc.0

            // load car.currentSpeed's address onto stack and call it's ToString() method
            ldarg.0
            ldflda int32 CILCars.CILCar::currSpeed
            call instance string [mscorlib]System.Int32::ToString()

            ldloc.0
            call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string)
            pop
            ret
        }
    }
}
