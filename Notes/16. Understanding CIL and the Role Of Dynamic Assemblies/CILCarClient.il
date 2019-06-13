.assembly extern mscorlib {
    .publickeytoken = (B7 7A 5C 56 19 34 E0 89)
    .ver 4:0:0:0
}

.assembly extern CILCars {
    .ver 1:0:0:0
}

.assembly CILCarClient {
    .hash algorithm 0x00008004
    .ver 1:0:0:0
}

.module CILCarClient.exe

.namespace CILCarClient {
    .class public auto ansi beforefieldinit Program extends [mscorlib]System.Object {
        .method public hidebysig static void Main(string[] args) cil managed {
            .entrypoint
            .maxstack 8
            
            .locals init ([0] class [CILCars]CILCars.CILCar myCILCar)

            ldstr "McQueen"
            ldc.i4 55
            

            newobj instance void [CILCars]CILCars.CILCar::.ctor(string, int32)
            stloc.0
            ldloc.0

            call void [CILCars]CILCars.CILCarInfo::Display(class [CILCars]CILCars.CILCar)
            ret
        }
    }
}

