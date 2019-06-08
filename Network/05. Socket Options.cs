// SOCKET OPTIONS

using System;
using System.Net;
using System.Net.Sockets;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // SetSocketOption(SocketOptionLevel level, SocketOptionName name, bool   optionValue);
            // SetSocketOption(SocketOptionLevel level, SocketOptionName name, int    optionValue);
            // SetSocketOption(SocketOptionLevel level, SocketOptionName name, byte[] optionValue);
            // SetSocketOption(SocketOptionLevel level, SocketOptionName name, object optionValue);


            // Level specifies the code in the system that interprets the option: the general socket code or some protocol-specific code
            // IP          Options for IP sockets
            // Socket      Options for the socket
            // Tcp         Options for TCP sockets
            // Udp         Options for UDP sockets

            // Socket Level

            // AcceptConnection             If true, socket is in listening mode
            // Broadcast                    If true, permits sending broadcast messages
            // Debug                        Records debugging information if true
            // DontLinger                   Closes socket gracefully without waiting for data
            // DontRoute                    Sends packet directly to interface addresses
            // Error                        Gets and clears the error status
            // ExclusiveAddressUse          Enables a socket to be bound for exclusive access
            // KeepAlive                    Sends TCP keep-alive packets
            // Linger                       Waits after closing the socket for any extra data
            // MaxConnections               Sets the maximum queue length used
            // OutOfBandInline              Allows receiving outof-band data
            // ReceiveBuffer                Sets the total persocket buffer reserved for receiving packets
            // ReceiveLowWater              Receives low water mark
            // ReceiveTimeout               Receives time-out
            // ReuseAddress                 Allows the socket to be bound to a port address that is already in use
            // SendBuffer                   Sets the total persocket buffer reserved for sending packets
            // SendLowWater                 Sends low water mark
            // SendTimeout                  Sends timeout value
            // Type                         Gets socket type    
            // UseLoopback                  Bypasses the networ kinterface when possible

            // IP Level

            // AddMembership                Adds an IP group membership
            // AddSourceMembership          Joins a source group
            // BlockSource                  Blocks data from a source  
            // BsdUrgent                    Uses urgent data (can only be set once and cannot be turned off)
            // DontFragment                 Doesn’t fragment the IP packet
            // DropMembership               Drops an IP group membership
            // DropSourceMembership         Drops a source group
            // Expedited                    Uses expedited data (can only be set once, and cannot turned off)
            // HeaderIncluded               Indicates that the data sent to the socket will include the IP header
            // IPOptions                    Specifies IP options to be used in outbound packets
            // IpTimeToLive                 Sets the IP packet time-to-live value
            // MulticastInterface           Sets the interface used for multicast packets
            // MulticastLoopback            IP multicast loopback
            // MulticastTimeToLive          Sets the IP multicast time to live
            // PacketInformation            Returns information about received packets
            // TypeOfService                Sets the IP type-ofservice field
            // UnblockSource                Sets the socket to non-blocking mode


            // UDP Level

            // ChecksumCoverage             Sets or gets UDP checksum coverage
            // NoChecksum                   Sends UDP packets with checksum set to zero

            // TCP Level

            // NoDelay                      Disables the Nagle algorithm for TCP packets
        }
    }
}