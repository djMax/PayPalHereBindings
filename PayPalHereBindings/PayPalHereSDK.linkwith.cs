using System;
using ObjCRuntime;

[assembly: LinkWith ("PayPalHereSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true)]
