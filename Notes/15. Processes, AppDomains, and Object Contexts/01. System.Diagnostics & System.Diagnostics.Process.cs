// System.Diagnostics Namespace
// The System.Diagnostics namespace defines a number of types that allow you to programmatically
// interact with processes and various diagnostic-related types such as the system event log and performance
// counters.

// Process 
// The Process class provides access to local and remote processes and also allows you to programmatically start and stop processes.

// ProcessModule 
// This type represents a module (*.dll or *.exe) that is loaded into a particular process. Understand that the ProcessModule type 
// can represent any module—COM-based, .NET-based, or traditional C-based binaries.

// ProcessModuleCollection 
// This provides a strongly typed collection of ProcessModule objects.

// ProcessStartInfo
// This specifies a set of values used when starting a process via the Process.Start() method.

// ProcessThread 
// This type represents a thread within a given process. Be aware that ProcessThread is a type used to diagnose a process’s thread
// set and is not used to spawn new threads of execution within a process.

// ProcessThreadCollection 
// This provides a strongly typed collection of ProcessThread objects.

// --------------------------------------------------------------------------------------------------------------------------------
// System.Diagnostics.Process 
// This class allows you to analyze the processes running on a given machine (local or remote). The Process class also provides 
// members that allow you to programmatically start and terminate processes, view (or modify) a  process’s priority level, and 
// obtain a list of active threads and/or loaded modules within a given process.

// ExitTime 
// This property gets the timestamp associated with the process that has terminated (represented with a DateTime type).

// Handle 
// This property returns the handle (represented by an IntPtr) associated to the process by the OS. This can be useful when 
// building .NET applications that need to communicate with unmanaged code.

// Id 
// This property gets the PID for the associated process.

// MachineName 
// This property gets the name of the computer the associated process is running on. 

// MainWindowTitle 
// MainWindowTitle gets the caption of the main window of the process (if the process does not have a main window, you receive an
// empty string).

// Modules 
// This property provides access to the strongly typed ProcessModuleCollection type, which represents the set of modules (*.dll or 
// *.exe) loaded within the current process.

// ProcessName 
// This property gets the name of the process (which, as you would assume, is the name of the application itself).

// Responding 
// This property gets a value indicating whether the user interface of the process is responding to user input (or is currently “hung”).

// StartTime 
// This property gets the time that the associated process was started (via a DateTime type). 

// Threads 
// This property gets the set of threads that are running in the associated process (represented via a collection of ProcessThread objects)

// CloseMainWindow() 
// This method closes a process that has a user interface by sending a close message to its main window.

// GetCurrentProcess() 
// This static method returns a new Process object that represents the currently active process.

// GetProcesses() 
// This static method returns an array of new Process objects running on a given machine.

// Kill()
// This method immediately stops the associated process.

// Start() 
// This method starts a process
