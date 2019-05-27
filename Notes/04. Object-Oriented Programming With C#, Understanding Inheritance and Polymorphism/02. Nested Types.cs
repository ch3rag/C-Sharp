// NESTED CLASSES

// Nested types allow you to gain complete control over the access level of the inner
// type because they may be declared privately (recall that non-nested classes cannot
// be declared using the private keyword).

// Because a nested type is a member of the containing class, it can access private
// members of the containing class.

// Often, a nested type is useful only as a helper for the outer class and is not intended
// for use by the outside world.

using System;
public class OuterClass {
	public class PublicInnerClass {
        
    }
    
    private class PrivateInnerClass {
        
    }
}
public static class Program {
    public static void Main() {
        OuterClass.PublicInnerClass innerOne;
        innerOne = new OuterClass.PublicInnerClass();
        
        // PRIVATE CLASS NOT ACCESSIBLE
        // OuterClass.PrivateInnerClass innerTwo;
        // innerTwo = new OuterClass.PrivateInnerClass();
        
    }
}