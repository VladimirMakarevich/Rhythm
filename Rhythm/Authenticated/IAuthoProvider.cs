﻿namespace Rhythm.Authenticated
{
    public interface IAuthoProvider
    {
        bool IsLoggedIn { get; }
        bool Login(string username, string password);
        void Logout();
    }
}
