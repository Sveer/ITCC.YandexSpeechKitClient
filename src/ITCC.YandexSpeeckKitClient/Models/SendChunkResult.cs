﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Net.Sockets;
using ITCC.YandexSpeeckKitClient.Enums;

namespace ITCC.YandexSpeeckKitClient.Models
{
    /// <summary>
    /// Audio data chunk uploading result.
    /// </summary>
    public class SendChunkResult
    {
        /// <summary>
        /// Successful data uploading result.
        /// </summary>
        public static SendChunkResult OkResult { get; } = new SendChunkResult();

        /// <summary>
        /// Data uploading timed out.
        /// </summary>
        public static SendChunkResult TimedOut { get; } = new SendChunkResult(System.Net.Sockets.SocketError.TimedOut);

        /// <summary>
        /// Operation status.
        /// </summary>
        public TransportStatus TransportStatus { get; }

        /// <summary>
        /// Contains error description if socker error occures.
        /// </summary>
        public SocketError? SocketError { get; }

        private SendChunkResult()
        {
            TransportStatus = TransportStatus.Ok;
        }
        internal SendChunkResult(SocketError socketError)
        {
            if (socketError == System.Net.Sockets.SocketError.TimedOut)
            {
                TransportStatus = TransportStatus.Timeout;
            }
            else
            {
                TransportStatus = TransportStatus.SocketError;
                SocketError = socketError;
            }
        }
    }
}
