//  System.Threading Namespace

// Interlocked 
// This type provides atomic operations for variables that are shared by multiple threads.

// Monitor 
// This type provides the synchronization of threading objects using locks and wait/signals. The C# lock keyword uses a Monitor 
// object under the hood.

// Mutex 
// This synchronization primitive can be used for synchronization between application domain boundaries.

// ParameterizedThreadStart 
// This delegate allows a thread to call methods that take any number of arguments.

// Semaphore 
// This type allows you to limit the number of threads that can access a resource, or a particular type of resource, concurrently.

// Thread 
// This type represents a thread that executes within the CLR. Using this type, you are able to spawn additional threads in the 
// originating AppDomain.

// ThreadPool 
// This type allows you to interact with the CLR-maintained thread pool within a given process.

// ThreadPriority 
// This enum represents a thread’s priority level (Highest, Normal, etc.).

// ThreadStart 
// This delegate is used to specify the method to call for a given thread. Unlike the ParameterizedThreadStart delegate, targets of 
// ThreadStart must always have the same prototype.

// ThreadState 
// This enum specifies the valid states a thread may take (Running, Aborted, etc.). 

// Timer 
// This type provides a mechanism for executing a method at specified intervals.

// TimerCallback 
// This delegate type is used in conjunction with Timer types.

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// System.Threading.Thread Class

// Useful Static Members
// CurrentContext
// This read-only property returns the context in which the thread is currently running.

// CurrentThread
// This read-only property returns a reference to the currently running thread. 

// GetDomain(), GetDomainID()
// These methods return a reference to the current AppDomain or the ID of the domain in which the current thread is running.

// Sleep() 
// This method suspends the current thread for a specified time

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// Instance-Level Members of the Thread Type

// IsAlive 
// Returns a Boolean that indicates whether this thread has been started (and has not yet terminated or aborted).

// IsBackground 
// Gets or sets a value indicating whether this thread is a “background thread”.

// Name 
// Allows you to establish a friendly text name of the thread.

// Priority
// Gets or sets the priority of a thread, which may be assigned a value from the ThreadPriority enumeration.

// ThreadState
// Gets the state of this thread, which may be assigned a value from the ThreadState enumeration.

// Abort() 
// Instructs the CLR to terminate the thread as soon as possible.

// Interrupt() 
// Interrupts (e.g., wakes) the current thread from a suitable wait period.

// Join() 
// Blocks the calling thread until the specified thread (the one on which Join() is called) exits.

// Resume()
// Resumes a thread that has been previously suspended.

// Start()
// Instructs the CLR to execute the thread ASAP.

// Suspend()
// Suspends the thread. If the thread is already suspended, a call to Suspend() has no effect.