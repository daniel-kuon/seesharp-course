using System.ComponentModel;
using System.Runtime.CompilerServices;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    // TODO 1: PropertyChanged auslösen (sender ist this); ohne Abonnenten darf nichts passieren.
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => throw new NotImplementedException();

    // TODO 2: Ist der neue Wert gleich dem alten (EqualityComparer<T>.Default), tue nichts und gib false zurück.
    // Sonst: Feld setzen, OnPropertyChanged(name) aufrufen und true zurückgeben.
    protected bool SetProperty<T>(ref T feld, T wert, [CallerMemberName] string? name = null)
        => throw new NotImplementedException();
}
