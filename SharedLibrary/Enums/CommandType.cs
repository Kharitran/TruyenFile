using System;

namespace SharedLibrary.Enums
{
    public enum CommandType
    {
        Login,
        Register,
        SendFile,
        RequestFile,
        ListFiles,
        Disconnect,
        StatusUpdate
    }
}