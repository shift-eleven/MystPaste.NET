﻿using System;
using System.Threading.Tasks;
using MystPaste.NET.Helpers;
using MystPaste.NET.Models;

namespace MystPaste.NET.Clients
{
    // TODO Map endpoints that require auth
    /// <summary>
    /// Represents a client to get information about users.
    /// </summary>
    public class UserClient : ApiClient
    {
        public UserClient(ApiRequester apiRequester) : base(apiRequester)
        { }

        /// <summary>
        /// Check if a user exists via their username.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>
        /// A boolean value representing the result. True if the user exists. False if the user doesn't exist
        /// </returns>
        public async Task<bool> CheckIfUserExistsAsync(string username)
        {
            return await ApiRequester.Get(ApiUrls.UserExists(username));
        }

        /// <summary>
        /// Gets a <see cref="User"/> from their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>A <see cref="User"/> object.</returns>
        public async Task<User> GetUserAsync(string username)
        {
            return await ApiRequester.Get<User>(ApiUrls.User(username));
        }

        /// <summary>
        /// Gets the currently authenticated user.
        /// </summary>
        /// <param name="auth">
        /// An optional authentication token.
        /// Is only optional when a token has not been passed to the <see cref="MystPasteClient"/>.</param>
        /// <returns>A <see cref="CurrentUser"/> object.</returns>
        /// <exception cref="ArgumentNullException">Throws when an auth token has not been passed to the client or the method.</exception>
        public async Task<CurrentUser> GetCurrentUserAsync(string auth = null)
        {
            auth ??= ApiRequester.Auth;
            if (auth is null)
                throw new ArgumentNullException(nameof(auth), "An authorization token needs to be passed in the constructor of the MystPasteClient or to the method");

            return await ApiRequester.Get<CurrentUser>(ApiUrls.CurrentUser(), auth);
        }
    }
}