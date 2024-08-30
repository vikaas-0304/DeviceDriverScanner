using System;
using System.Management;

namespace DeviceDriverScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scanning system drivers and connected devices...\n");

            ScanDrivers();
            ScanConnectedDevices();

            Console.WriteLine("\nScan completed.");
        }

        static void ScanDrivers()
        {
            Console.WriteLine("Installed Drivers:\n");

            // Query all drivers installed in the system
            string query = "SELECT * FROM Win32_PnPSignedDriver";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine($"Driver: {obj["DeviceName"]} | Manufacturer: {obj["Manufacturer"]} | Version: {obj["DriverVersion"]}");
            }
        }

        static void ScanConnectedDevices()
        {
            Console.WriteLine("\nConnected Devices:\n");

            // Query all connected devices
            string query = "SELECT * FROM Win32_PnPEntity";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine($"Device: {obj["Name"]} | Status: {obj["Status"]}");
            }
        }
    }
}
