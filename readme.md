# Limitless LED Commands

## Summary

Windows command line appliction for controlling LimitlessLED light bulbs via the Wifi bridge.   Currently still a work in progress.

## Features

The idea is to build a simple command line application to allow the LimitlessLED light bulbs to be controlled from a windows computer.  This would allow for easy batch scripting, and scheduling of commands.

## ToDo

Oh soo many things.  These are the high prioriy ones.

* Replicate the remotes
	* ~~Add all hex codes to BridgeCommands~~
	* Write functions for white led remote buttons
	* Write functions for colour led remote buttons
	* Add command line arguments for each of the remote buttons
* Add command line option for defining the bridge IP address
* Move fancy and and user defined functions to seperate class (eg WakeUpCall, and Strobe)
* Move the core functions commands and functions to a DLL so the code can be used in other applications
* Replace the simple switch-case for interperting command line arguements

## Contributions

You want to help?  Absolutely.. Just be patient with me and github.